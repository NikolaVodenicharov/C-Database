using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class Medicament
    {
        public Medicament()
        {
            
        }

        public Medicament(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
