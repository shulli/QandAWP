using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using QandA.Data;
using QandA.Data.Models;

namespace QandA.ViewModel.UnitTest
{
    [TestClass]
    public class TakeTestUnitTest
    {
        //Ensure that Take Test View Model displays a random question when first started
        [TestMethod]
        public void TakeTestDisplaysData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);

            Assert.IsNotNull(viewModel.CurrentQuestion);
        }

        //Ensure that Take Test View Model contains the correct number of questions available for the selected test
        [TestMethod]
        public void TakeTestDisplaysCorrectNumberOfQuestionsData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            //Pass Test to View Model 
            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);

            Assert.AreEqual(dataRepository.GetTestById(0).QuestionsGroups.SelectMany(x => x.Questions).Count(), viewModel.QuestionsCount);


        }

        //Ensure that Take Test View Model displays the correct question data for the randomly selected question
        [TestMethod]
        public void TakeTestDisplaysRandomQuestionData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            //Pass Test to View Model 
            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);

            int questionId = viewModel.CurrentQuestion.Id;

            Question questionById = dataRepository.GetQuestionById(questionId);

            Assert.AreEqual(questionById.QuestionPhrase, viewModel.CurrentQuestion.QuestionPhrase);
        }

        //Ensure that Take Test View Model displays all the answer options for the displayed question
        [TestMethod]
        public void TakeTestDisplaysAllAnswersForRandomQuestionData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            //Pass Test to View Model 
            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);

            int questionId = viewModel.CurrentQuestion.Id;

            Question questionById = dataRepository.GetQuestionById(questionId);
            foreach (Answer answerById in questionById.Answers)
            {
                Assert.AreEqual(answerById.AnswerPhrase ,
                                viewModel.CurrentQuestion.Answers.FirstOrDefault(x => x.Id == answerById.Id).AnswerPhrase);
            }
            
        }

        //Ensure that Take Test View Model displays the correct possible answers for the displayed question
        [TestMethod]
        public void TakeTestDisplaysCorrectAnswersForRandomQuestionData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            //Pass Test to View Model 
            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);

            int questionId = viewModel.CurrentQuestion.Id;

            Question questionById = dataRepository.GetQuestionById(questionId);
            foreach (Answer answerById in questionById.Answers.Where(x=>x.IsCorrectAnswer))
            {
                Assert.AreEqual(answerById.AnswerPhrase,viewModel.CurrentQuestion.Answers.FirstOrDefault(x => x.Id == answerById.Id).AnswerPhrase);
                Assert.AreEqual(answerById.IsCorrectAnswer, viewModel.CurrentQuestion.Answers.FirstOrDefault(x => x.Id == answerById.Id).IsCorrectAnswer);

            }
        }

        //Ensure that Take Test View Model displays the correct selected answer
        [TestMethod]
        public void TakeTestDisplaysCorrectSelectedAnswerData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            TakeTestViewModel viewModel = new TakeTestViewModel(navigationService, dataRepository, dialogService);

            //Pass Test to View Model 
            viewModel.CurrentTest = dataRepository.GetTestById(0);
            viewModel.PrepareTestCommand.Execute(null);


            Answer answerToProvide = viewModel.CurrentQuestion.Answers.FirstOrDefault();


            viewModel.SelectAnswerCommand.Execute(answerToProvide);


            Assert.AreEqual(answerToProvide, viewModel.UserAnswers.LastOrDefault().Value);

            
        }
    }
}
