using System.ComponentModel.DataAnnotations;

namespace COVID_vaccination_patient_system.Models.DTO
{
    public class PatientDTO
    {
        [Required]        
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }
    }
}
