using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WindowsPhone.Client.Converters
{
    public class TakeTestButtonContentConverter : IValueConverter
    {
        //Displays finish if the current question is the last one
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool) value) ? "Finish" : "Next Question";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
