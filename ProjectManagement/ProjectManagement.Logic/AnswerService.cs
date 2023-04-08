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
            answerRepository.SaveChanges();
        }

        public Answer GetAnswerById(int answerId)
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
            var answer = answerRepository.GetById(updatedAnswer.Id);
            if (answer != null)
            {
                answer.Title = updatedAnswer.Title;
                answer.Description = updatedAnswer.Description;
                answerRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Answer with id {updatedAnswer.Id} does not exist.");
            }
        }

        public void RemoveAnswer(int answerId)
        {
            var answer = answerRepository.GetById(answerId);
            if (answer != null)
            {
                answerRepository.Remove(answer);
                answerRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Answer with id {answerId} does not exist.");
            }
        }
    }
}