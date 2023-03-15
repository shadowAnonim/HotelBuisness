using Hotels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Hotels
{
    internal static class Utils
    {
        public static HotelsContext db = new HotelsContext();

        public static int x = 0;

        public static void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool checkEmail(string input)
        {
            return Regex.IsMatch(input, "^[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}$", RegexOptions.IgnoreCase);
        }

        public static bool checkPhone(string input)
        {
            return Regex.IsMatch(input, "^\\+?(\\d{1,3})?[- .]?\\(?(?:\\d{2,3})\\)?[- .]?\\d\\d\\d[- .]?\\d\\d\\d\\d$/");
        }

        public static byte[] DateToBytes(DateTime date)
        {
            return BitConverter.GetBytes(date.Ticks);
        }

        public static DateTime BytesToDate(byte[] bytes)
        {
            try
            {
                long a = BitConverter.ToInt64(bytes, 0);
                return new DateTime(1980, 1, 1).AddMicroseconds(a);
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }
        }
    }
}
