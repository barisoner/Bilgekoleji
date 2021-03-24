using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface IStudentLessonGradeRepository
    {
        IQueryable<StudentLessonGrade> studentLessongrades { get; }

        void CreateStudentLessonGrade(StudentLessonGrade studentLessongrade);


        void DeleteStudentLessonGrade(int studentLessongradeid);


        StudentLessonGrade GetById(int studentLessongradeid);

        void UpdateStudentLessonGrade(StudentLessonGrade studentLessongrade);
    }
}
