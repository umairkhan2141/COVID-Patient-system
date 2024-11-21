using COVID_vaccination_patient_system.Data;
using COVID_vaccination_patient_system.Models;
using COVID_vaccination_patient_system.Models.DTO;
using COVID_vaccination_patient_system.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace COVID_vaccination_patient_system.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepository _repo;

        public PatientController(IPatientRepository db)
        {
            _repo = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return Ok(_repo.GetAll().ToList());
        }

        [HttpGet("{id:int}", Name = "GetPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Patient> GetPatient(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("CustomError", "invalid id");
                return BadRequest(ModelState);
            }

            Patient? patient = _repo.Get(x => x.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }
            if(patient.VaccinationStatus == "Vaccinated")
            {
                patient.Vaccinations = _repo.GetVaccinations(x => x.PatientID == patient.PatientID).ToList();
            }            

            return Ok(patient);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Patient> CreatePatient([FromBody] PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                return BadRequest();
            }

            if (patientDTO.Gender.ToLower() != "male" && patientDTO.Gender.ToLower() != "female")
            {
                ModelState.AddModelError("CustomError", "Gender is invalid");
                return BadRequest(ModelState);
            }

            Patient patient = new()
            {
                Name = patientDTO.Name,
                Age = patientDTO.Age,
                Gender = patientDTO.Gender,
                VaccinationStatus = "Unvaccinated"
            };

            _repo.Add(patient);
            _repo.Save();

            return CreatedAtRoute("GetPatient", new { id = patient.PatientID }, patient);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePatient(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("CustomError", "invalid id");
                return BadRequest(ModelState);
            }

            Patient? patient = _repo.Get(x => x.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }

            _repo.Delete(patient);
            _repo.Save();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Patient> UpdatePatient(int id, [FromBody] PatientDTO patientDTO)
        {
            if(id == 0 || patientDTO == null)
            {
                return BadRequest();
            }

            if (patientDTO.Gender.ToLower() != "male" && patientDTO.Gender.ToLower() != "female")
            {
                ModelState.AddModelError("CustomError", "Gender is invalid");
                return BadRequest(ModelState);
            }

            Patient? patient = _repo.Get(x => x.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.Name = patientDTO.Name;
            patient.Age = patientDTO.Age;
            patient.Gender = patientDTO.Gender;

            _repo.Update(patient);
            _repo.Save();

            return Ok(patient);
        }

        [HttpPost("{id:int}", Name = "AddVaccination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Patient> AddVaccination(int id, [FromBody] VaccinationDTO vaccinationDTO)
        {
            if (id == 0 || vaccinationDTO == null)
            {
                return BadRequest();
            }

            Patient? patient = _repo.Get(x => x.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }

            Vaccination vaccination = new()
            {
                Name = vaccinationDTO.Name,
                Dose = vaccinationDTO.Dose,
                Patient = patient,
                DateTime = DateTime.Now
            };

            _repo.AddVaccination(vaccination);

            if(patient.VaccinationStatus == "Unvaccinated")
            {
                patient.VaccinationStatus = "Vaccinated";
                _repo.Update(patient);
            }

            _repo.Save();

            patient.Vaccinations = _repo.GetVaccinations(x => x.PatientID == patient.PatientID).ToList();

            return Ok(patient);
        }
    }
}
