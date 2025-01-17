using Microsoft.Data.SqlClient;
using CrudOperation.Models;
using System.Collections.Generic;

namespace CrudOperation.DataAccess
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all students
        public IEnumerable<Student> GetAllStudents()
        {
            var students = new List<Student>();
            using var connection = new SqlConnection(_connectionString);
            const string query = "SELECT * FROM Students";
            using var command = new SqlCommand(query, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student(
                    (int)reader["Id"],
                    reader["Name"]?.ToString(),
                    (int?)reader["Age"],
                    reader["Email"]?.ToString()
                ));
            }
            return students;
        }

        // Get student by ID
        public Student GetStudentById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "SELECT * FROM Students WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Student(
                    (int)reader["Id"],
                    reader["Name"]?.ToString(),
                    (int?)reader["Age"],
                    reader["Email"]?.ToString()
                );
            }
            return null;
        }

        // Add a student
        public void AddStudent(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", student.Name ?? string.Empty);
            command.Parameters.AddWithValue("@Age", student.Age ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", student.Email ?? string.Empty);
            connection.Open();
            command.ExecuteNonQuery();
        }

        // Update a student
        public void UpdateStudent(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Name", student.Name ?? string.Empty);
            command.Parameters.AddWithValue("@Age", student.Age ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", student.Email ?? string.Empty);
            connection.Open();
            command.ExecuteNonQuery();
        }

        // Delete a student
        public void DeleteStudent(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "DELETE FROM Students WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
