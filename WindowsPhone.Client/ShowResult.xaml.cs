using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QandA.Data.Models;
using QandA.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WindowsPhone.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowResult 
    {
        private ShowResultViewModel Vm
        {
            get
            {
                return (ShowResultViewModel)DataContext;
            }
        }
        public ShowResult()
        {
            this.InitializeComponent(); 
            HardwareButtons.BackPressed += HardwareBackPressed;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareBackPressed;

        }
        private void HardwareBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            Vm.FinishTestCommand.Execute(null);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            Vm.UserAnswers = (List<KeyValuePair<Question, Answer>>) e.Parameter;
            Vm.PrepareResultsCommand.Execute(null);
         
        }
    }
}
