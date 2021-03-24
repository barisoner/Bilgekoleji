using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class StudentLessonRepository : IStudentLessonRepository
    {
        private StuWareContext _context;

        public StudentLessonRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<StudentLesson> StudentLessons => _context.StudentLesson;


        public void CreateStudentLesson(StudentLesson studentLesson)
        {
            _context.StudentLesson.Add(studentLesson);
            _context.SaveChanges();
        }

        public void DeleteStudentLesson(int studentLessonId)
        {
            var studentLesson = GetById(studentLessonId);

            if (studentLesson != null)
            {
                _context.StudentLesson.Remove(studentLesson);
                _context.SaveChanges();
            }
        }

        public StudentLesson GetById(int studentLessonId)
        {
            return _context.StudentLesson.FirstOrDefault(i => i.ID == studentLessonId);
        }


        public void UpdateStudentLesson(StudentLesson studentLesson)
        {
            _context.StudentLesson.Update(studentLesson);
            _context.SaveChanges();
        }

    }
}
