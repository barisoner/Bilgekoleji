using System;
using System.Collections.Generic;
using System.Text;

namespace StuWare.Model
{
    public class District
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
