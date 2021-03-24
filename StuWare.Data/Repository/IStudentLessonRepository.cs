using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface IStudentLessonRepository
    {
        IQueryable<StudentLesson> StudentLessons { get; }

        public void CreateStudentLesson(StudentLesson studentLesson);

        public void DeleteStudentLesson(int studentLessonId);

        public StudentLesson GetById(int studentLessonId);


        public void UpdateStudentLesson(StudentLesson studentLesson);

    }
}
