using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {

        private StuWareContext _context;

        public TeacherRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<Teacher> Teachers => _context.Teacher;

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int teacherId)
        {
            var teacher = GetById(teacherId);

            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public Teacher GetById(int TeacherId)
        {
            return _context.Teacher.FirstOrDefault(i => i.ID == TeacherId);
        }

        public void UpdateTeacher(Teacher Teacher)
        {
            _context.Teacher.Update(Teacher);
            _context.SaveChanges();
        }
    }
}
