using System.ComponentModel.DataAnnotations;

namespace COVID_vaccination_patient_system.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Vaccination Status")]
        public string VaccinationStatus { get; set; }

        public ICollection<Vaccination> Vaccinations { get; set; }
    }
}
