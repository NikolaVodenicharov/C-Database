using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public class Patient
    {
        public Patient()
        {

        }

        public Patient(string firstName, string lastName, string email, bool hasInsurance, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.HasInsurance = hasInsurance;
            this.Address = address;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
        public string Address { get; set; }

        public ICollection<Diagnosis> Diagnoses { get; set; } = new HashSet<Diagnosis>();
        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
