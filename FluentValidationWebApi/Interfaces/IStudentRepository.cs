using FluentValidationWebApi.Models;

namespace FluentValidationWebApi.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
    }
}
