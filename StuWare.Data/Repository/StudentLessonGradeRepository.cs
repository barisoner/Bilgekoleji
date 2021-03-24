using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class StudentLessonGradeRepository : IStudentLessonGradeRepository
    {
        private StuWareContext _context;

        public StudentLessonGradeRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<StudentLessonGrade> studentLessongrades => _context.StudentLessonGrade;

        public void CreateStudentLessonGrade(StudentLessonGrade studentLessongrade)
        {
            _context.StudentLessonGrade.Add(studentLessongrade);
            _context.SaveChanges();
        }

        public void DeleteStudentLessonGrade(int studentLessongradeid)
        {
            var studentLessongrade = GetById(studentLessongradeid);

            if (studentLessongrade != null)
            {
                _context.StudentLessonGrade.Remove(studentLessongrade);
                _context.SaveChanges();
            }
        }

        public StudentLessonGrade GetById(int studentLessongradeid)
        {
            return _context.StudentLessonGrade.FirstOrDefault(i => i.ID == studentLessongradeid);
        }

        public void UpdateStudentLessonGrade(StudentLessonGrade studentLessongrade)
        {
            _context.StudentLessonGrade.Update(studentLessongrade);
            _context.SaveChanges();
        }
    }
}
