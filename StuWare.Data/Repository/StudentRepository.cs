using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StuWareContext _context;

        public StudentRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<Student> Students => _context.Student;


        public void CreateStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = GetById(studentId);

            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
        }

        public Student GetById(int studentId)
        {
            return _context.Student.FirstOrDefault(i => i.ID == studentId);
        }


        public void UpdateStudent(Student student)
        {
            _context.Student.Update(student);
            _context.SaveChanges();
        }

    }
}
