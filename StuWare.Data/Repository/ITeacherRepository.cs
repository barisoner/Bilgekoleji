using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface ITeacherRepository
    {
        IQueryable<Teacher> Teachers { get; }

        void CreateTeacher(Teacher teacher);


        void DeleteTeacher (int teacherId);


        Teacher GetById(int teacherId);

        void UpdateTeacher(Teacher teacher);
    }
}
