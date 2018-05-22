namespace Hospital.DatabaseInitializer.Generators
{
    using Hospital.Data;
    using Hospital.Models;
    using System;
    //using System.IO;


    public class PatientGenerator
    {
        private static Random rnd = new Random();

        public static Patient NewPatient(HospitalDbContext context)
        {
            string firstName = NameGenerator.FirstName();
            string lastName = NameGenerator.LastName();
            string email = EmailGenerator.NewEmail(firstName + lastName);
            string address = AddressGenerator.NewAddress();

            var patient = new Patient(firstName, lastName, email, true, address);
            patient.Visitations = GenerateVisitations(patient);
            patient.Diagnoses = GenerateDiagnoses(patient);

            return patient;
        }
        private static Diagnosis[] GenerateDiagnoses(Patient patient)
        {
            var diagnoseNames = new string[] 
            {
                "Limp Scurvy",
                "Fading Infection",
                "Cow Feet",
                "Incurable Ebola",
                "Snake Blight",
                "Spider Asthma",
                "Sinister Body",
                "Spine Diptheria",
                "Pygmy Decay",
                "King's Arthritis",
                "Desert Rash",
                "Deteriorating Salmonella",
                "Shadow Anthrax",
                "Hiccup Meningitis",
                "Fading Depression",
                "Lion Infertility",
                "Wolf Delirium",
                "Humming Measles",
                "Incurable Stomach",
                "Grave Heart",
            };
            //var diagnoseNames = File.ReadAllLines("<INSERT DIR HERE>");

            int diagnoseCount = rnd.Next(1, 4);
            var diagnoses = new Diagnosis[diagnoseCount];
            for (int i = 0; i < diagnoseCount; i++)
            {
                string diagnoseName = diagnoseNames[rnd.Next(diagnoseNames.Length)];

                var diagnosis = new Diagnosis()
                {
                    Name = diagnoseName,
                    Patient = patient
                };

                diagnoses[i] = diagnosis;
            }

            return diagnoses;
        }
        private static Visitation[] GenerateVisitations(Patient patient)
        {
            int visitationCount = rnd.Next(1, 5);

            var visitations = new Visitation[visitationCount];

            for (int i = 0; i < visitationCount; i++)
            {
                var visitationDate = RandomDay(2005);

                var visitation = new Visitation(visitationDate, patient);

                visitations[i] = visitation;
            }

            return visitations;
        }
        private static DateTime RandomDay(int startYear)
        {
            DateTime start = new DateTime(startYear, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
