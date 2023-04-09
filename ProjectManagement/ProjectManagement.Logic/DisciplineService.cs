using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.Logic
{
    public class DisciplineService
    {
        private readonly IDisciplineRepository disciplineRepository;
        public DisciplineService(IDisciplineRepository disciplineRepository)
        {
            this.disciplineRepository = disciplineRepository;
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return disciplineRepository.GetAll();
        }

        public void AddDiscipline(Discipline discipline)
        {
            disciplineRepository.Add(discipline);
            
        }

        public Discipline GetDisciplineById(Guid disciplineId)
        {
            var discipline = disciplineRepository.GetById(disciplineId);
            if (discipline != null)
            {
                return discipline;
            }
            else
            {
                throw new ArgumentException($"Discipline with id {disciplineId} does not exist.");
            }
        }

        public void UpdateDisciline(Discipline updatedDiscipline)
        {
            disciplineRepository.Update(updatedDiscipline);
        }

        public void RemoveDiscipline(Guid disciplineId)
        {
            var discipline = disciplineRepository.GetById(disciplineId);
            if (discipline != null)
            {
                disciplineRepository.Remove(disciplineId);
            }
            else
            {
                throw new ArgumentException($"Discipline with id {disciplineId} does not exist.");
            }
        }
    }
}
