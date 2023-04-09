using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Logic
{
    public class QuestionService
    {
        private readonly IQuestionRepository questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return questionRepository.GetAll();
        }
        public void AddQuestion(Question question)
        {
            questionRepository.Add(question);
        }
        public void RemoveQuestion(Guid questionId)
        {
            var question = questionRepository.GetById(questionId);
            if (question != null)
            {
                questionRepository.Remove(questionId);
              
            }
            else
            {
                throw new ArgumentException($"Question with id {questionId} does not exist.");
            }
        }
        public Question GetQuestionById(Guid questionId)
        {
            var question = questionRepository.GetById(questionId);
            if (question != null)
            {
                return question;
            }
            else
            {
                throw new ArgumentException($"Question with id {questionId} does not exist.");
            }
        }
        public void UpdateQuestion(Question updatedQuestion)
        {
           questionRepository.Update(updatedQuestion);
        }

    }
}