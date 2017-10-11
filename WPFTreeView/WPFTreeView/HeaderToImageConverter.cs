using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

using System.IO;

namespace WPFTreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null)
                return null;

            var image = "Images/file.png";

            var fi = new FileInfo(path);

            if (fi.Attributes.HasFlag(FileAttributes.Directory))
                if (fi.DirectoryName == null)
                    image = "Images/drive.png";
                else
                    image = "Images/folder-closed.png";
            
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
