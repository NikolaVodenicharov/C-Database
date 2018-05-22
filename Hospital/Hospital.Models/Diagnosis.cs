using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class Diagnosis
    {
        public Diagnosis()
        {

        }

        public Diagnosis(string name, Patient patient)
        {
            this.Name = name;
            this.Patient = patient;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
