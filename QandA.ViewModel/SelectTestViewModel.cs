using System.Collections.Generic;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using QandA.Data;
using QandA.Data.Models;

namespace QandA.ViewModel
{
    public class SelectTestViewModel : ViewModelBase
    {
        #region Services

        private readonly IDataRepository _dataRepository;
        private readonly INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        private List<Test> _tests;

        public List<Test> Tests
        {
            get
            {
                return _tests;
            }
            set
            {
                Set(ref _tests, value);
            }
        }

        #endregion

        #region Constructor

        public SelectTestViewModel(
            INavigationService navigationService,IDataRepository dataRepository,IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dataRepository = dataRepository;
            _dialogService = dialogService;

        }

        #endregion

        #region Select Test Command

        private RelayCommand<Test> _selectTestCommand;

        public RelayCommand<Test> SelectTestCommand
        {
            get
            {
                return _selectTestCommand
                       ?? (_selectTestCommand = new RelayCommand<Test>(
                           ExecuteSelectTest));

            }
        }

        private void ExecuteSelectTest(Test selectedTest)
        {
            _navigationService.NavigateTo(
                               ViewModelLocator.TakeTestKey,
                               selectedTest);
        }

        #endregion

        #region Get Test Command

        private RelayCommand _getTestsCommand;

        public RelayCommand GetTestsCommand
        {
            get
            {
                return _getTestsCommand
                       ?? (_getTestsCommand = new RelayCommand(
                           ExecuteGetTests));

            }
        }
        private void ExecuteGetTests()
        {
            Tests = _dataRepository.GetAllTests();
        }

        #endregion

        #region Exit Application Command

        private RelayCommand _exitApplicationCommand;

        public RelayCommand ExitApplicationCommand
        {
            get
            {
                return _exitApplicationCommand
                       ?? (_exitApplicationCommand = new RelayCommand(
                           ExecuteExitApplication));

            }
        }

        private async void ExecuteExitApplication()
        {
            await _dialogService.ShowMessage("Are you sure you want to exit the application?",
               "Confirmation", "Exit", "Cancel", (confirmed) =>
               {
                   if (confirmed)
                   {
                       Application.Current.Exit();
                   }
               });
        }

        #endregion
    }
}
