using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabileApi.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {

            CreateMap<Entities.Courses, Models.CourseDto>();
            CreateMap<Models.CourseDto,Entities.Courses>();

        }
    }
}
