using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.Logic
{
    public class AnswerService
    {
        private readonly IAnswerRepository answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        public IEnumerable<Answer> GetAnswers()
        {
            return answerRepository.GetAll();
        }
        public void AddAnswer(Answer answer)
        {
            answerRepository.Add(answer);
            
        }

        public Answer GetAnswerById(Guid answerId)
        {
            var answer = answerRepository.GetById(answerId);
            if (answer != null)
            {
                return answer;
            }
            else
            {
                throw new ArgumentException($"Answer with id {answerId} does not exist.");
            }
        }

        public void UpdateAnswer(Answer updatedAnswer)
        {
            answerRepository.Update(updatedAnswer); 
        }

        public void RemoveAnswer(Guid answerId)
        {
            var answer = answerRepository.GetById(answerId);
            if (answer != null)
            {
                answerRepository.Remove(answerId);
            }
            else
            {
                throw new ArgumentException($"Answer with id {answerId} does not exist.");
            }
        }
    }
}