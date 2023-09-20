namespace FluentValidationWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
    }
}

