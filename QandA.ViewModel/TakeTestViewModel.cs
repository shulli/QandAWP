using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using QandA.Data;
using QandA.Data.Models;
using QandA.ViewModel.Extensions;

namespace QandA.ViewModel
{
    public class TakeTestViewModel : ViewModelBase
    {
        #region Services

        private readonly IDataRepository _dataRepository;
        private readonly INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        public List<KeyValuePair<Question, Answer>> UserAnswers { get; set; }
        private int _questionIndex;
        public int QuestionIndex
        {
            get
            {
                return _questionIndex;
            }
            set
            {
                Set(ref _questionIndex, value);
                RaisePropertyChanged("IsFinalQuestion");
                //Raise the property changed event for the IsFinal question
                //as well in order to update its value and notify the View 
                //that the value has been updated
            }
        }

        private int _questionsCount;
        public int QuestionsCount
        {
            get
            {
                return _questionsCount;
            }
            set
            {
                Set(ref _questionsCount, value);
                
            }
        }
        
        public bool IsFinalQuestion
        {
            get
            {
                return QuestionIndex+1 ==QuestionsCount;
            }
            
        }

        private Question _currentQuestion;

        public Question CurrentQuestion
        {
            get
            {
                return _currentQuestion;
            }
            set
            {
                Set(ref _currentQuestion, value);
                CurrentQuestionAnswers = value.Answers.Shuffle(new Random()).ToList();
            }
        }

        private List<Answer> _currentQuestionAnswers;

        public List<Answer> CurrentQuestionAnswers
        {
            get
            {
                return _currentQuestionAnswers;
            }
            set
            {
                Set(ref _currentQuestionAnswers, value);
            }
        }


        public List<Question> CurrentTestQuestions  { get; set; }
        public Test CurrentTest { get; set; }

        #endregion

        #region Constructor

        public TakeTestViewModel(INavigationService navigationService,IDataRepository dataRepository,IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dataRepository = dataRepository;
            _dialogService = dialogService;

        

            UserAnswers = new List<KeyValuePair<Question, Answer>>();

        }

        #endregion

        #region Select Answer Command

        private RelayCommand<Answer> _selectAnswerCommand;

        public RelayCommand<Answer> SelectAnswerCommand
        {
            get
            {
                return _selectAnswerCommand
                       ?? (_selectAnswerCommand = new RelayCommand<Answer>(
                           ExecuteSelectAnswer));
                
            }
        }

        private void ExecuteSelectAnswer(Answer selectedAnswer)
        {
            UserAnswers.Add(new KeyValuePair<Question, Answer>(CurrentQuestion,selectedAnswer));
            if (!IsFinalQuestion)
            {
                QuestionIndex++;
                CurrentQuestion = CurrentTestQuestions[_questionIndex];
            }
            else
            {
                _navigationService.NavigateTo(
                    ViewModelLocator.ShowResultKey,
                    UserAnswers);
            }
            
        }

        #endregion

        #region Prepare Test Command

        private RelayCommand _prepareTestCommand;

        public RelayCommand PrepareTestCommand
        {
            get
            {
                return _prepareTestCommand
                       ?? (_prepareTestCommand = new RelayCommand(
                           ExecutePrepareTest));

            }
        }
        private void ExecutePrepareTest()
        {
            CurrentTestQuestions = new List<Question>();
            foreach (var questionGroup in CurrentTest.QuestionsGroups)
            {
                CurrentTestQuestions.AddRange(questionGroup.Questions.Shuffle(new Random()).ToList());   
            }
            QuestionIndex = 0;
            QuestionsCount = CurrentTestQuestions.Count;
            CurrentQuestion = CurrentTestQuestions[_questionIndex];
        }

        #endregion

        #region Exit Test Command

        private RelayCommand _exitTestCommand;

        public RelayCommand  ExitTestCommand
        {
            get
            {
                return _exitTestCommand
                       ?? (_exitTestCommand = new RelayCommand(
                           ExecuteExitTest));

            }
        }
        private async void ExecuteExitTest()
        {
            await _dialogService.ShowMessage("Are you sure you want to go back and loose all progress in the current Test?",
                "Confirmation", "Go Back", "Cancel", (confirmed) =>
                {
                    if (confirmed)
                    {
                        UserAnswers = new List<KeyValuePair<Question, Answer>>();
                        _navigationService.GoBack();
                    }
                });
        }

        #endregion
    }
}
