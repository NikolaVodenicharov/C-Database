using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class Doctor
    {
        public Doctor()
        {

        }

        public Doctor(string name, string speciality)
        {
            this.Name = name;
            this.Speciality = speciality;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
