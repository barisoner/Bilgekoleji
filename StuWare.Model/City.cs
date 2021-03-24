using System;
using System.Collections.Generic;
using System.Text;

namespace StuWare.Model
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
