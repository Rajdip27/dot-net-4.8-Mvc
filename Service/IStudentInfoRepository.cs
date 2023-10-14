using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebAppMvcProject.ViewModel;

namespace WebAppMvcProject.Service
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfoVM>> GetStudentInfoAsync();

      
        Task<StudentInfoVM> CreateAsync(StudentInfoVM studentInfo);
        Task<StudentInfoVM> UpdateAsync(int Id, StudentInfoVM studentInfo);
        Task<StudentInfoVM> GetById(int Id);
        Task<StudentInfoVM> DeleteAsync(int Id);
    }
}
