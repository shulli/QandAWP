using System.Collections.Generic;
using QandA.Data.Models;

namespace QandA.Data
{
    public interface IDataRepository
    {
        List<Test> GetAllTests();
        Test GetTestById(int testId);
        Test GetTestByName(string testName);
        List<QuestionsGroup> GetQuestionsGroupByTestId(int testId);
        List<Question> GetQuestionsTestId(int testId);
        Question GetQuestionById(int questionId);
    }
}