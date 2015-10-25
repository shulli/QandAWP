using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using QandA.Data;

namespace QandA.ViewModel.UnitTest
{
    [TestClass]
    public class SelectTestUnitTest
    {
        //Ensure that Take Test Select View Model displays the test choices
        [TestMethod]
        public void TestSelectTestDisplaysData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            SelectTestViewModel viewModel = new SelectTestViewModel(navigationService, dataRepository, dialogService);
            viewModel.GetTestsCommand.Execute(null);

            Assert.IsNotNull(viewModel.Tests);
        }

        //Ensure that Take Test View Model displays "General Questions" as on of the options
        [TestMethod]
        public void TestSelectDisplaysGeneralQuestionsData()
        {
            INavigationService navigationService = new NavigationService();
            IDialogService dialogService = new DialogService();
            IDataRepository dataRepository = new QuestionsDesignRepository();
            SelectTestViewModel viewModel = new SelectTestViewModel(navigationService, dataRepository, dialogService);
            viewModel.GetTestsCommand.Execute(null);

            Assert.IsNotNull(viewModel.Tests.Where(x => x.TestName == "General Questions"));
        }
    }
}
