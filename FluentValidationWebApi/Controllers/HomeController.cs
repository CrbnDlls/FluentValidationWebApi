using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FluentValidationWebApi.Interfaces;
using FluentValidationWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FluentValidationWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        IMapper _mapper;
        IValidator<StudentBindingModel> _validator;
        IStudentRepository _studentRepository;

        public HomeController(IMapper mapper, IValidator<StudentBindingModel> validator, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _studentRepository = studentRepository;
        }

        [HttpPost(Name ="Save")]
        public async Task<string> Save(StudentBindingModel studentBinding)
        {
            var result = await _validator.ValidateAsync(studentBinding);
            bool IsSaved = false;
            int? Id = null;
            if (result.IsValid)
            {
                try
                {
                    var student = await _studentRepository.AddAsync(_mapper.Map<Student>(studentBinding));
                    Id = student.Id;
                    IsSaved = true;
                }
                catch (Exception ex)
                {
                    result.Errors.Add(new ValidationFailure("Entity", "Save failed. " + ex.Message));
                }
            }

            return JsonConvert.SerializeObject(new { IsSaved, result, Id } );
        }
    }
}
