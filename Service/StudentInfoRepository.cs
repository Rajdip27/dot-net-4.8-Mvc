using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebAppMvcProject.ViewModel;

namespace WebAppMvcProject.Service
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentInfoRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StudentInfoVM> CreateAsync(StudentInfoVM studentInfo)
        {
            var data = _mapper.Map<StudentInfo>(studentInfo);

            _dbContext.StudentInfoes.Add(data);

            await _dbContext.SaveChangesAsync();

            return studentInfo;
        }

        public async Task<StudentInfoVM> DeleteAsync(int Id)
        {
            var studentInfo = await _dbContext.StudentInfoes.FindAsync(Id);

            if (studentInfo == null)
                return null;

            _dbContext.StudentInfoes.Remove(studentInfo);

            await _dbContext.SaveChangesAsync();

            return new StudentInfoVM();
        }

        public async Task<StudentInfoVM> GetById(int Id)
        {
            var studentInfo = await _dbContext.StudentInfoes.FindAsync(Id);
            var data= _mapper.Map<StudentInfoVM>(studentInfo);
            return data;
        }

        public async Task<List<StudentInfoVM>> GetStudentInfoAsync()
        {
            var studentInfos = await _dbContext.StudentInfoes.ToListAsync();
            var data = _mapper.Map<List<StudentInfoVM>>(studentInfos); 
            return data ;
        }

        public async Task<StudentInfoVM> UpdateAsync(int Id, StudentInfoVM studentInfo)
        {
            var existingStudentInfo = await _dbContext.StudentInfoes.FindAsync(Id);

            if (existingStudentInfo == null)
                return null;
            
            _mapper.Map(studentInfo, existingStudentInfo);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<StudentInfoVM>(existingStudentInfo);
        }
    }
}