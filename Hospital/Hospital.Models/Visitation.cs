using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public class Visitation
    {
        public Visitation()
        {

        }

        public Visitation(DateTime date, Patient patient)
        {
            this.Date = date;
            this.Patient = patient;
        }

        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
