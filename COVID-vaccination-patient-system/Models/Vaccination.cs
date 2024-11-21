using System.ComponentModel.DataAnnotations;

namespace COVID_vaccination_patient_system.Models
{
    public class Vaccination
    {
        public int VaccinationID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Dose { get; set; }

        [Required]
        [Display (Name = "Date and Time")]
        public DateTime DateTime { get; set; }


        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
