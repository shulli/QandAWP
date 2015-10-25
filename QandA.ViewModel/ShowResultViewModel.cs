using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using QandA.Data;
using QandA.Data.Models;

namespace QandA.ViewModel
{
    public class ShowResultViewModel :ViewModelBase
    {
        #region Services

        private readonly IDataRepository _dataRepository;
        private readonly INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        public string TestResultDisplayPercentage 
        { 
            get
            {
                if (TestResults.Any())
                {
                    return (((decimal)TestCorrectAnswers / (decimal)TestResults.Count) * (decimal)100.00).ToString("0.##");

                }
                else
                {
                    return String.Empty;
                }
            } 
        }

        public int TestCorrectAnswers
        {
            get { return TestResults.Count(x => x.Value.IsCorrectAnswer); }
        }
        public List<KeyValuePair<Question, Answer>> UserAnswers { get; set; }

        private List<KeyValuePair<int, Answer>> _testResults;

        public List<KeyValuePair<int, Answer>> TestResults
        {
            get
            {
                return _testResults;
            }
            set
            {
                Set(ref _testResults, value);
                RaisePropertyChanged("TestCorrectAnswers");
                RaisePropertyChanged("TestResultDisplayPercentage");
            }
        }

        #endregion

        #region Constructor

        public ShowResultViewModel(INavigationService navigationService, IDataRepository dataRepository, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dataRepository = dataRepository;
            _dialogService = dialogService;

        }

        #endregion

        #region Prepare Results Command

        private RelayCommand _prepareResultsCommand;

        public RelayCommand PrepareResultsCommand
        {
            get
            {
                return _prepareResultsCommand
                       ?? (_prepareResultsCommand = new RelayCommand(
                           ExecutePrepareResults));

            }
        }
        private void ExecutePrepareResults()
        {
            TestResults = UserAnswers.Select(answer => new KeyValuePair<int, Answer>(UserAnswers.IndexOf(answer) + 1, answer.Value)).ToList();
            
        }

        #endregion

        #region Finish Test Command

        private RelayCommand _finishTestCommand;

        public RelayCommand FinishTestCommand
        {
            get
            {
                return _finishTestCommand
                       ?? (_finishTestCommand = new RelayCommand(
                           ExecuteFinishTest));

            }
        }

        private void ExecuteFinishTest()
        {
            UserAnswers = new List<KeyValuePair<Question, Answer>>();
            TestResults = new List<KeyValuePair<int, Answer>>();
            _navigationService.NavigateTo(ViewModelLocator.SelectTestKey);

        }

        #endregion
    }
}
