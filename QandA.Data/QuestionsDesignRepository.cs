using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using QandA.Data.Models;

namespace QandA.Data
{
    public class QuestionsDesignRepository : IDataRepository
    {
        private List<Test> _tests;

        public QuestionsDesignRepository()
        {
            SeedMockRepository();
        }

        private void SeedMockRepository()
        {
            _tests = new List<Test>()
            {
                new Test()
                {
                    Id = 0,
                    TestName = "General Questions",
                    QuestionsGroups = new List<QuestionsGroup>()
                    {
                        new QuestionsGroup()
                        {
                            Id = 0,
                            GroupName = "General Questions",
                            Questions = new List<Question>()
                            {
                                new Question()
                                {
                                    Id = 0,
                                    QuestionPhrase = "What is the largest country (in size) in the world?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 0,AnswerPhrase = "Russia", IsCorrectAnswer = true},
                                            new Answer() {Id = 1,AnswerPhrase = "India", IsCorrectAnswer = false},
                                            new Answer() {Id = 2,AnswerPhrase = "China", IsCorrectAnswer = false},
                                            new Answer() {Id = 3,AnswerPhrase = "USA", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 1,
                                    QuestionPhrase = "What is the capital city of Australia? ",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 4,AnswerPhrase = "Canberra", IsCorrectAnswer = true},
                                            new Answer() {Id = 5,AnswerPhrase = "Sydney", IsCorrectAnswer = false},
                                            new Answer() {Id = 6,AnswerPhrase = "Melbourne", IsCorrectAnswer = false},
                                            new Answer() {Id = 7,AnswerPhrase = "Adelaide", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 2,
                                    QuestionPhrase = "What is the capital of Greece?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 8,AnswerPhrase = "Athens", IsCorrectAnswer = true},
                                            new Answer() {Id = 9,AnswerPhrase = "Rome", IsCorrectAnswer = false},
                                            new Answer() {Id = 10,AnswerPhrase = "Bissau", IsCorrectAnswer = false},
                                            new Answer() {Id = 11,AnswerPhrase = "Dublin", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 3,
                                    QuestionPhrase = "What is the currency of Indonesia?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 12,AnswerPhrase = "Rupiah", IsCorrectAnswer = true},
                                            new Answer() {Id = 13,AnswerPhrase = "Dinar", IsCorrectAnswer = false},
                                            new Answer() {Id = 14,AnswerPhrase = "Pound", IsCorrectAnswer = false},
                                            new Answer() {Id = 15,AnswerPhrase = "Dollar", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 4,
                                    QuestionPhrase = "How many letters are in the English language?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 16,AnswerPhrase = "26", IsCorrectAnswer = true},
                                            new Answer() {Id = 17,AnswerPhrase = "23", IsCorrectAnswer = false},
                                            new Answer() {Id = 18,AnswerPhrase = "29", IsCorrectAnswer = false},
                                            new Answer() {Id = 19,AnswerPhrase = "25", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 5,
                                    QuestionPhrase = "Where is the Golden Gate Bridge located?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 20,AnswerPhrase = "California", IsCorrectAnswer = true},
                                            new Answer() {Id = 21,AnswerPhrase = "Michigan", IsCorrectAnswer = false},
                                            new Answer() {Id = 22,AnswerPhrase = "Massachusetts", IsCorrectAnswer = false},
                                            new Answer() {Id = 23,AnswerPhrase = "New York", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 6,
                                    QuestionPhrase = "Which is the only piece able to jump over other pieces in chess?",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 24,AnswerPhrase = "Knight", IsCorrectAnswer = true},
                                            new Answer() {Id = 25,AnswerPhrase = "King", IsCorrectAnswer = false},
                                            new Answer() {Id = 26,AnswerPhrase = "Queen", IsCorrectAnswer = false},
                                            new Answer() {Id = 27,AnswerPhrase = "Elephant", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 7,
                                    QuestionPhrase = "How many continent are in planet earth? ",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 28,AnswerPhrase = "7", IsCorrectAnswer = true},
                                            new Answer() {Id = 29,AnswerPhrase = "6", IsCorrectAnswer = false},
                                            new Answer() {Id = 30,AnswerPhrase = "25", IsCorrectAnswer = false},
                                            new Answer() {Id = 31,AnswerPhrase = "208", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 8,
                                    QuestionPhrase = "The headquarters of UN are located in? ",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 32,AnswerPhrase = "New York", IsCorrectAnswer = true},
                                            new Answer() {Id = 33,AnswerPhrase = "London", IsCorrectAnswer = false},
                                            new Answer() {Id = 34,AnswerPhrase = "Paris", IsCorrectAnswer = false},
                                            new Answer() {Id = 35,AnswerPhrase = "Berlin", IsCorrectAnswer = false}
                                        }
                                },
                                new Question()
                                {
                                    Id = 9,
                                    QuestionPhrase = "Thomas Edison was ? ",
                                    Answers =
                                        new List<Answer>()
                                        {
                                            new Answer() {Id = 36,AnswerPhrase = "an Inventor", IsCorrectAnswer = true},
                                            new Answer() {Id = 37,AnswerPhrase = "a Doctor", IsCorrectAnswer = false},
                                            new Answer() {Id = 38,AnswerPhrase = "a Musician", IsCorrectAnswer = false},
                                            new Answer() {Id = 39,AnswerPhrase = "a Poet", IsCorrectAnswer = false}
                                        }
                                },
                            }
                        }
                    }
                }
            };
        }

        public List<Test> GetAllTests()
        {
            return _tests;
        }

        public Test GetTestById(int testId)
        {
            return _tests.FirstOrDefault(x => x.Id == testId);
        }

        public Test GetTestByName(string testName)
        {
            return _tests.FirstOrDefault(x => x.TestName == testName);
        }

        public List<QuestionsGroup> GetQuestionsGroupByTestId(int testId)
        {
            return _tests.FirstOrDefault(x => x.Id == testId).QuestionsGroups;
        }
        public List<Question> GetQuestionsTestId(int testId)
        {
            return _tests.FirstOrDefault(x => x.Id == testId).QuestionsGroups.SelectMany(x=>x.Questions).ToList();
        }

        public Question GetQuestionById(int questionId)
        {
            return _tests.SelectMany(x=> x.QuestionsGroups).SelectMany(x=>x.Questions).FirstOrDefault(x => x.Id==questionId);
        }
    } 
}
