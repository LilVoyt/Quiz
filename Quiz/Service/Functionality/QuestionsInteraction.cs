using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.Functionality
{
    internal class QuestionsInteraction
    {
        public static void AddQuestionFromConsole()
        {
            Console.WriteLine("Enter question text:");
            string questionText = Console.ReadLine();

            var answers = new List<(string answerText, bool isCorrect)>();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter text for answer {i + 1}:");
                string answerText = Console.ReadLine();

                Console.WriteLine("Is this answer correct? (yes/no):");
                bool isCorrect = Console.ReadLine().ToLower() == "yes";

                answers.Add((answerText, isCorrect));
            }

            AddQuestionWithAnswers(questionText, answers);
            Console.WriteLine("Question and answers added successfully.");
        }

        public static void AddQuestionWithAnswers(string questionText, List<(string answerText, bool isCorrect)> answers)
        {
            using (var context = new QuizContext())
            {
                var question = new Question
                {
                    Text = questionText,
                    Answers = answers.Select(a => new Answer { Text = a.answerText, IsCorrect = a.isCorrect }).ToList()
                };

                context.Questions.Add(question);
                context.SaveChanges();
            }
        }
        public static void DisplayAllQuestionsWithAnswers()
        {
            using (var context = new QuizContext())
            {
                var questionsWithAnswers = context.Questions
                                                  .Join(context.Answers,
                                                        q => q.QuestionId,
                                                        a => a.QuestionId,
                                                        (q, a) => new { QuestionText = q.Text, AnswerText = a.Text, IsCorrect = a.IsCorrect })
                                                  .ToList();

                foreach (var item in questionsWithAnswers)
                {
                    Console.WriteLine($"Question: {item.QuestionText}");
                    Console.WriteLine($"  Answer: {item.AnswerText} (Correct: {item.IsCorrect})");
                }
            }
        }


    }
}
