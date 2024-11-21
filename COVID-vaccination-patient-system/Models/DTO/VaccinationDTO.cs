using System.ComponentModel.DataAnnotations;

namespace COVID_vaccination_patient_system.Models.DTO
{
    public class VaccinationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Dose { get; set; }
    }
}
