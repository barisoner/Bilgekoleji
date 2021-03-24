using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface ILessonRepository
    {
        IQueryable<Lesson> Lessons { get; }

        void CreateLesson(Lesson lesson);

        void DeleteLesson(int lessonid);

        Lesson GetById(int lessonid);

        void UpdateLesson(Lesson lesson);
    }
}
