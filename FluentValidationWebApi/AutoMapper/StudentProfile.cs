using AutoMapper;
using FluentValidationWebApi.Models;

namespace FluentValidationWebApi.AutoMapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<StudentBindingModel, Student>();
        }
    }
}
