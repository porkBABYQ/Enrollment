using AutoMapper;
using Enrollment.App.Models;
using Enrollment.DataModel;

namespace Enrollment.App.Configuration
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
            CreateMap<Teacher, TeacherVM>().ReverseMap();
        }
    }
}
