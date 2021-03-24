using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private StuWareContext _context;

        public LessonRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<Lesson> Lessons => _context.Lesson;

        public void CreateLesson(Lesson lesson)
        {
            _context.Lesson.Add(lesson);
            _context.SaveChanges();
        }

        public Lesson GetById(int lessonid)
        {
            return _context.Lesson.FirstOrDefault(i => i.ID == lessonid);
        }

        public void DeleteLesson(int lessonid)
        {
            var lesson = GetById(lessonid);

            if (lesson != null)
            {
                _context.Lesson.Remove(lesson);
                _context.SaveChanges();
            }
        }

        public void UpdateLesson(Lesson lesson)
        {
            _context.Lesson.Update(lesson);
            _context.SaveChanges();
        }
    }
}
