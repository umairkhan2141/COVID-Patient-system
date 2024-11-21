using COVID_vaccination_patient_system.Data;
using COVID_vaccination_patient_system.Models;
using COVID_vaccination_patient_system.Repository.IRepository;
using System.Linq.Expressions;

namespace COVID_vaccination_patient_system.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
              _db = db;
        }
        public void AddVaccination(Vaccination obj)
        {
            _db.Vaccinations.Add(obj);
        }

        public IEnumerable<Vaccination> GetVaccinations(Expression<Func<Vaccination, bool>> filter)
        {
            return _db.Vaccinations.Where(filter);
        }
    }
}
