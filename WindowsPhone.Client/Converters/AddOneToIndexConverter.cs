using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WindowsPhone.Client.Converters
{
    public class AddOneToIndexConverter :IValueConverter
    {
        //Add one to an array index to convert it to a number from a set
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (((int)value+1));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
