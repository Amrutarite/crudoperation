namespace CrudOperation.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }  // Allow Name to be nullable
        public int? Age { get; set; }  // Allow Age to be nullable
        public string? Email { get; set; }  // Allow Email to be nullable

        // Parameterless constructor for model binding
        public Student() { }

        // Constructor to initialize properties with values
        public Student(int id, string? name, int? age, string? email) =>
            (Id, Name, Age, Email) = (id, name, age, email);
    }
}
