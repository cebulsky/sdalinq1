using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleLinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\";
            //GetFilesNamesAndSizeWithoutLinq(path);
            //GetTop5LargestFileUsingLinq(path);
            //GetCulturesWithCommaSeparatorWithoutLinq();
            //GetCulturesWithCommaSeparatorUsingLinq();
            //ShowDecimalSeparatorInfo(".");
            //ShowDecimalSeparatorInfo(",");
            //ShowAlbanianDayNames();
            //ShowUniqueDateTimeFormats();
            ShowFibonacciNumbers();
            Console.ReadLine();
        }

        private static void ShowFibonacciNumbers()
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };

            // query created, and immediately executed
            var twoNumbersFromTheMiddle = fibonacci.Skip(2).Take(2);

            foreach (var number in twoNumbersFromTheMiddle)
            {
                Console.WriteLine(number);
            }
        }

        private static void ShowUniqueDateTimeFormats()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var dateTimePatterns = from ci in availableCultures
                                   select ci.DateTimeFormat.FullDateTimePattern;

            foreach (var t in dateTimePatterns.Distinct())
            {
                Console.WriteLine(t);
            }

            var uniqueDateTimePatternCount = dateTimePatterns.Distinct().Count();

            Console.WriteLine();
            Console.WriteLine($"Unikalnych formatów datetime jest: {uniqueDateTimePatternCount}");
        }

        private static void ShowAlbanianDayNames()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var test = from ci in availableCultures
                       where ci.DisplayName.Contains("Alban")
                       select ci.DateTimeFormat.DayNames;

            foreach (var t in test.First())
            {
                Console.WriteLine(t);
            }
        }

        private static void ShowDecimalSeparatorInfo(string decimalSeparator)
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var culturesCountWithParticularSeparator =
                from ci in availableCultures
                where ci.NumberFormat.CurrencyDecimalSeparator.Equals(decimalSeparator)
                select ci;

            Console.WriteLine($"Kultur o separatorze '{decimalSeparator}' jest: {culturesCountWithParticularSeparator.Count()}");
        }

        private static void GetCulturesWithCommaSeparatorUsingLinq()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var culturesWithCommaSeparator = from ci in availableCultures
                                             where ci.NumberFormat.CurrencyDecimalSeparator.Equals(",")
                                             select ci;

            foreach (var ci in culturesWithCommaSeparator)
            {
                Console.WriteLine($"{ci.DisplayName}");
            }
        }

        private static void GetCulturesWithCommaSeparatorWithoutLinq()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var ci in availableCultures)
            {
                if (ci.NumberFormat.NumberDecimalSeparator == ",")
                {
                    Console.WriteLine($"{ci.DisplayName}");
                }
            }
        }

        private static void GetFilesNamesAndSizeWithoutLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var filesInfo = directoryInfo.GetFiles();
            Array.Sort(filesInfo, new FileSizeComparer());

            //foreach (var fi in filesInfo)
            //{
            //    Console.WriteLine($"{fi.Name,-25} size: {fi.Length,10:N0}");
            //}

            for (int i = 0; i < 5; i++)
            {
                var fi = filesInfo[i];
                Console.WriteLine($"{fi.Name,-25} size: {fi.Length,10:N0}");
            }
        }

        private static void GetTop5LargestFileUsingLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var filesInfo = from file in directoryInfo.GetFiles()
                            orderby file.Length descending
                            select file;
            foreach (var fi in filesInfo.Take(5))
            {
                Console.WriteLine($"{fi.Name,-25} size: {fi.Length,10:N0}");
            }
        }
    }
    public class FileSizeComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}