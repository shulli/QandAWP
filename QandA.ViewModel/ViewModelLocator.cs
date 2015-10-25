using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using QandA.Data;

namespace QandA.ViewModel
{
    /// <summary>
    /// This class contains static references to the most relevant view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// The key used by the NavigationService to go to the second page.
        /// </summary>
        public const string SelectTestKey = "SelectTest";
        public const string TakeTestKey = "TakeTest";
        public const string ShowResultKey = "ShowResult";

     

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SelectTestViewModel SelectTest
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectTestViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TakeTestViewModel TakeTest
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TakeTestViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ShowResultViewModel ShowResult
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShowResultViewModel>();
            }
        }

        /// <summary>
        /// This property can be used to force the application to run with design time data.
        /// </summary>
        public static bool UseDesignTimeData
        {
            get
            {
                return true;
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            if (!ViewModelBase.IsInDesignModeStatic
                && !UseDesignTimeData)
            {
                // Use this service in production.
                //Should be replaced with production data repository
                SimpleIoc.Default.Register<IDataRepository, QuestionsDesignRepository>();

            }
            else
            {
                // Use this service in Blend or when forcing the use of design time data.
                SimpleIoc.Default.Register<IDataRepository, QuestionsDesignRepository>();
            }

            SimpleIoc.Default.Register<ShowResultViewModel>();
            SimpleIoc.Default.Register<SelectTestViewModel>();
            SimpleIoc.Default.Register<TakeTestViewModel>();
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}