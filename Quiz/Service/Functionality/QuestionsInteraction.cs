﻿using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Console.WriteLine("Enter the topic:");
            string topic = Console.ReadLine();

            var answers = new List<(string answerText, bool isCorrect)>();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter text for answer {i + 1}:");
                string answerText = Console.ReadLine();

                Console.WriteLine("Is this answer correct? (yes/no):");
                bool isCorrect = Console.ReadLine().ToLower() == "yes";

                answers.Add((answerText, isCorrect));
            }

            AddQuestionWithAnswers(questionText, topic, answers);
            Console.WriteLine("Question and answers added successfully.");
        }

        public static void AddQuestionWithAnswers(string questionText, string topic, List<(string answerText, bool isCorrect)> answers)
        {
            using (var context = new QuizContext())
            {
                var question = new Question
                {
                    Text = questionText,
                    Topic = topic,
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

                var groupedQuestions = questionsWithAnswers
                                       .GroupBy(qa => qa.QuestionText)
                                       .ToList();

                foreach (var group in groupedQuestions)
                {
                    Console.WriteLine($"Question: {group.Key}");
                    foreach (var answer in group)
                    {
                        Console.WriteLine($"  Answer: {answer.AnswerText} (Correct: {answer.IsCorrect})");
                    }
                }
            }
        }

        public static void DisplayQuestionsWithAnswers(string topic)
        {
            using (var context = new QuizContext())
            {
                var questionsWithAnswers = context.Questions
                                                  .Where(x => x.Topic == topic)
                                                  .Join(context.Answers,
                                                        q => q.QuestionId,
                                                        a => a.QuestionId,
                                                        (q, a) => new { QuestionText = q.Text, AnswerText = a.Text, IsCorrect = a.IsCorrect })
                                                  .ToList();

                var groupedQuestions = questionsWithAnswers
                                       .GroupBy(qa => qa.QuestionText)
                                       .ToList();

                foreach (var group in groupedQuestions)
                {
                    Console.WriteLine($"Question: {group.Key}");
                    foreach (var answer in group)
                    {
                        Console.WriteLine($"  Answer: {answer.AnswerText} (Correct: {answer.IsCorrect})");
                    }
                }
            }
        }

        public static void DeleteQuestion(string questionText) //cascad delete
        {
            using (var context = new QuizContext())
            {
                var question = context.Questions
                                      .Include(q => q.Answers)
                                      .FirstOrDefault(x => x.Text == questionText);

                if (question == null)
                {
                    Console.WriteLine("Error, such question does not exist");
                }
                else
                {
                    context.Questions.Remove(question);
                    context.SaveChanges();
                    Console.WriteLine("Question and its answers were successfully deleted.");
                }
            }
        }

        public static int AnswerQuestion()
        {
            Console.WriteLine("Here are the questions: ");
            var questions = GetRandomQuestionsList();
            int grade = 0;

            foreach (var question in questions)
            {
                Console.WriteLine($"Question: {question.Text}, possible answers: ");
                int count = 1; 
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"Answer [{count}]: {answer.Text}");
                    count++; 
                }
                Console.WriteLine("Enter the number of the answer: ");
                int num = int.Parse(Console.ReadLine());

                if (question.Answers.ElementAt(num - 1).IsCorrect)
                {
                    grade++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                }
            }
            Console.WriteLine($"Your total grade is: {grade} out of {questions.Count}");
            return grade;
        }

        public static List<Question> GetRandomQuestionsList()
        {
            using (var context = new QuizContext())
            {
                Random rng = new Random();
                var questions = context.Questions
                                       .Include(q => q.Answers) 
                                       .ToList();

                return questions.OrderBy(q => rng.Next()).ToList();
            }
        }

        public static string ChooseTopic()
        {
            Console.WriteLine("Enter the topic you need(IT, ....): ");
            string answer = Console.ReadLine();

            return answer;
        }
    }
}
