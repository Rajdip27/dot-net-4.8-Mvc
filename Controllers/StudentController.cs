using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppMvcProject.Service;
using WebAppMvcProject.ViewModel;

namespace WebAppMvcProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentInfoRepository _studentInfoRepository;

        public StudentController(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var data = await _studentInfoRepository.GetStudentInfoAsync();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            StudentInfoVM studentInfo = new StudentInfoVM();

            return View(studentInfo);
        }
        [HttpPost]
        public async Task<ActionResult> Create(StudentInfoVM studentInfo)
        {
            if (ModelState.IsValid)
            {
                await _studentInfoRepository.CreateAsync(studentInfo);

                return RedirectToAction("Index");

            }
            return View(studentInfo);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var data = await _studentInfoRepository.GetById(Id);

            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int Id, StudentInfoVM studentInfo)
        {
            if (ModelState.IsValid)
            {
                await _studentInfoRepository.UpdateAsync(Id,studentInfo);

                return RedirectToAction(nameof(Index));
            }
            return View(studentInfo);
        }
        public async Task<ActionResult>Delete(int Id)
        {
            if (Id != 0)
            {
                await _studentInfoRepository.DeleteAsync(Id);

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
            
        }
      
    }
}