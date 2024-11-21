using COVID_vaccination_patient_system.Models;
using System.Linq.Expressions;

namespace COVID_vaccination_patient_system.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void AddVaccination(Vaccination obj);
        IEnumerable<Vaccination> GetVaccinations(Expression<Func<Vaccination, bool>> filter);
    }
}
