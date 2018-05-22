namespace Hospital.DatabaseInitializer.Generators
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Hospital.Data;
    using Hospital.Models;

    public class PrescriptionGenerator
    {
        internal static void InitialPrescriptionSeed(HospitalDbContext context)
        {
            int[] allMedicamentIds = context.Medicaments.Select(d => d.Id).ToArray();
            int[] allPatientIds = context.Patients.Select(p => p.Id).ToArray();

            foreach (int patientId in allPatientIds)
            {
                int[] medicamentIds = GenerateMedicamentIds(allMedicamentIds);

                HashSet<PatientMedicament> prescriptions = GeneratePerscriptions(patientId, medicamentIds);

                context.Patients.Find(patientId).Prescriptions = prescriptions;
            }

            context.SaveChanges();
        }

        private static HashSet<PatientMedicament> GeneratePerscriptions(int patientId, int[] medicamentIds)
        {
            var prescriptions = new HashSet<PatientMedicament>();
            foreach (int medicamentId in medicamentIds)
            {
                var prescription = new PatientMedicament(patientId, medicamentId);
                prescriptions.Add(prescription);
            }

            return prescriptions;
        }

        private static int[] GenerateMedicamentIds(int[] allMedicamentIds)
        {
            Random rnd = new Random();
            int patientMedicamentsCount = rnd.Next(1, 4);
            int[] medicamentIds = new int[patientMedicamentsCount];
            for (int id = 0; id < patientMedicamentsCount; id++)
            {
                int index = -1;
                while (!allMedicamentIds.Contains(index) || medicamentIds.Contains(index))
                {
                    index = rnd.Next(allMedicamentIds.Max());
                }

                medicamentIds[id] = index;
            }

            return medicamentIds;
        }

        public static void NewPrescription(int patientId, int medicamentId, HospitalDbContext context)
        {
            var prescription = new PatientMedicament(patientId, medicamentId);
            context.Patients.Find(patientId).Prescriptions.Add(prescription);
            context.SaveChanges();
        }
        public static void NewPrescription(Patient patient, Medicament medicament, HospitalDbContext context)
        {
            var prescription = new PatientMedicament(patient, medicament);
            patient.Prescriptions.Add(prescription);
            context.SaveChanges();
        }
    }
}
