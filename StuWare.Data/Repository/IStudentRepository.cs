using StuWare.Model;
using System.Collections.Generic;
using System.Linq;

namespace StuWare.Data.Repository
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }

        void CreateStudent(Student student);


        void DeleteStudent(int studentId);


        Student GetById(int studentId);
     
        void UpdateStudent(Student student);
     
    }
}
