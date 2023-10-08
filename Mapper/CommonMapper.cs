using AutoMapper;
using WebAppMvcProject.ViewModel;

namespace WebAppMvcProject.Mapper
{
    public class CommonMapper:Profile
    {
        public CommonMapper()
        {
            CreateMap<StudentInfoVM, StudentInfo>().ReverseMap();
        }
    }
}