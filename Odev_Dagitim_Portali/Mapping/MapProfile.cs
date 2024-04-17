using AutoMapper;
using Odev_Dagitim_Portali.Dtos;
using Odev_Dagitim_Portali.Models;

namespace Odev_Dagitim_Portali.Mapping
{
    public class MapProfile: Profile
    {

        public MapProfile()
        {
            CreateMap<Homework, HomeworkDto>().ReverseMap();
            CreateMap<Homework_submission, Homework_submissionDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<University_department,University_departmentDto>().ReverseMap();

        }
    }
 
}
