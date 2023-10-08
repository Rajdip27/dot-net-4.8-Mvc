using Microsoft.AspNetCore.Mvc;
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
        public async Task <ActionResult> Index()
        {
            var data = await _studentInfoRepository.GetStudentInfoAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<ActionResult> CreateOrEdit(int Id)
        {
            if(Id == 0)
                return View(new StudentInfoVM());
            
            else
                return View(await _studentInfoRepository.GetById(Id));
        }

    }
}