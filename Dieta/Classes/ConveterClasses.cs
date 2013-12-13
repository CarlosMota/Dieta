using Microsoft.Phone;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Dieta.Classes 
{
    public class ConveterClasses : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (value != null)
                {
                    WriteableBitmap pict = null;
                    var imageStream = store.OpenFile((string)value, FileMode.Open, FileAccess.Read);
                    pict = PictureDecoder.DecodeJpeg(imageStream);
                    return pict;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
