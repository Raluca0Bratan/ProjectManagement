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
            disciplineRepository.SaveChanges();
        }

        public Discipline GetDisciplineById(int disciplineId)
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
            var discipline = disicplineRepository.GetById(updatedDiscipline.Id);
            if (discipline != null)
            {
                discipline.Title = updatedDiscipline.Title;
                discipline.Description = updatedDiscipline.Description;
                disciplineRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Discipline with id {updatedDiscipline.Id} does not exist.");
            }
        }

        public void RemoveDiscipline(int disciplineId)
        {
            var discipline = disciplineRepository.GetById(disciplineId);
            if (discipline != null)
            {
                disciplineRepository.Remove(discipline);
                disciplineRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Discipline with id {disciplineId} does not exist.");
            }
        }
    }
}
