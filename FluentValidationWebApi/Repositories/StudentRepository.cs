using FluentValidationWebApi.Interfaces;
using FluentValidationWebApi.Models;
using Newtonsoft.Json;

namespace FluentValidationWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<Student> AddAsync(Student student)
        {
            if (File.Exists("students.txt"))
            {
                string[] lines = await File.ReadAllLinesAsync("students.txt");

                for (int i = 1; i <= lines.Length + 1; i++)
                {
                    bool IsUnique = true;
                    for (int j = 0; j < lines.Length; j++)
                    {
                        var entity = JsonConvert.DeserializeObject<Student>(lines[j]);
                        if (entity == null || entity.Id == i)
                        {
                            IsUnique = false;
                            break;
                        }
                    }
                    if (IsUnique)
                    {
                        student.Id = i;
                        break;
                    }
                }
            }
            else
            {
                student.Id = 1;
            }
            await File.AppendAllLinesAsync("students.txt", new[] { JsonConvert.SerializeObject(student) });

            return student;
        }
    }
}
