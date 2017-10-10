using LinqConsoleApp.EF;
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
            //ShowFibonacciNumbers();
            //Filtering();
            //ConcatUnionTest();
            EkstraklasaTest();
            Console.ReadLine();
        }

        private static void EkstraklasaTest()
        {
            using (var dbContext = new EkstraklasaContext())
            {
                var trenerzyBezKlubu = from trener in dbContext.Trener
                                       where !trener.Klub.Any()
                                       select trener;
                foreach (var trener in trenerzyBezKlubu)
                {
                    Console.WriteLine($"{trener.Imie} {trener.Nazwisko}");
                }

                Console.WriteLine();
                Console.WriteLine("Ilosc zawodnikow w klubach:");
                var klubZawodnicy = dbContext.Zawodnik.GroupBy(z => z.Klub);

                foreach (var kz in klubZawodnicy)
                {
                    Console.WriteLine($"Klub: {kz.Key.Nazwa}, zawodników: {kz.Count()}");
                }
            }
        }

        private static void ConcatUnionTest()
        {
            string[] penPineapple = { "Pen", "Pineapple" };
            string[] applePen = { "Apple", "Pen" };

            Console.WriteLine("Metoda Concat zwróci:");
            var concatenated = penPineapple.Concat(applePen);

            foreach (var word in concatenated)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
            Console.WriteLine("Metoda Union zwróci:");
            var unioned = penPineapple.Union(applePen);

            foreach (var word in unioned)
            {
                Console.WriteLine(word);
            }
        }

        private static void Filtering()
        {
            List<Employee> employees = new List<Employee>();
            employees.AddRange(new Employee[] {
                new Employee()
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    Salary = 2500,
                    HireDate = DateTime.Now.AddYears(-2),
                },
                new Employee()
                {
                    Name = "Piotr",
                    Surname = "Nowak",
                    Salary = 3000,
                    HireDate = DateTime.Now.AddYears(-1),
                },
                new Employee()
                {
                    Name = "Mariusz",
                    Surname = "Kolas",
                    Salary = 4000,
                    HireDate = DateTime.Now.AddYears(-5),
                },
                new Employee()
                {
                    Name = "Marcin",
                    Surname = "Lewandowski",
                    Salary = 3200,
                    HireDate = DateTime.Now.AddYears(-3),
                },
                new Employee()
                {
                    Name = "Joanna",
                    Surname = "Kowalczyk",
                    Salary = 2800,
                    HireDate = DateTime.Now.AddYears(-3),
                },
                new Employee()
                {
                    Name = "Agnieszka",
                    Surname = "Marchlewicz",
                    Salary = 3400,
                    HireDate = DateTime.Now.AddYears(-2),
                },
                new Employee()
                {
                    Name = "Marianna",
                    Surname = "Mazur",
                    Salary = 5300,
                    HireDate = DateTime.Now.AddYears(-1),
                }
            });

            var sortedEmployees = employees.OrderByDescending(e => e.Salary).ThenBy(e => e.HireDate);

            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine($"Salary: {emp.Salary,-10} HireDate: {emp.HireDate.ToShortDateString()} {emp.Surname,-20} {emp.Name,-20}");
            }

            Console.WriteLine();
            Console.WriteLine($"Czy wszyscy zarabiają >3000? {employees.All(e => e.Salary > 3000)}");
            Console.WriteLine($"Czy ktokolwiek zarabia <3000? {employees.Any(e => e.Salary < 3000)}");

            Console.WriteLine();

            var groupedEmployees = employees.GroupBy(e => e.HireDate.Year);

            foreach (var ge in groupedEmployees)
            {
                Console.WriteLine($"Rok zatrudnienia: {ge.Key}");
                foreach (var emp in ge)
                {
                    Console.WriteLine($"{emp.Name} {emp.Surname}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Analogiczny sposob grupowania z anomimowym typem:");

            var anotherGroupedEmployees = from emp in employees
                                          group emp by emp.HireDate.Year into ge
                                          select new { RokZatrudnienie = ge.Key, Pracownicy = ge };

            foreach (var ge in anotherGroupedEmployees)
            {
                Console.WriteLine($"Rok zatrudnienia: {ge.RokZatrudnienie}");
                foreach (var emp in ge.Pracownicy)
                {
                    Console.WriteLine($"{emp.Name} {emp.Surname}");
                }
            }

            //var filteredEmployees = employees.Where(e => e.Salary > 4000);

            //foreach (var emp in filteredEmployees)
            //{
            //    Console.WriteLine($"{emp.Surname}, {emp.Name}, Salary: {emp.Salary}");
            //}

            //Console.WriteLine($"Maksymalne zarobiki: {employees.Max(e => e.Salary)}");
            //Console.WriteLine($"Średnie zarobiki: {employees.Average(e => e.Salary)}");
            //Console.WriteLine($"Minimalne zarobiki: {employees.Min(e => e.Salary)}");

            //object[] objects = {
            //    new Employee()
            //    {
            //    Name = "Marianna",
            //    Surname = "Mazur",
            //    Salary = 5300,
            //    HireDate = DateTime.Now.AddYears(-1),
            //    },
            //    "napis",
            //    34.5,
            //    new Employee()
            //    {
            //    Name = "Marcin",
            //    Surname = "Lewandowski",
            //    Salary = 3200,
            //    HireDate = DateTime.Now.AddYears(-3),
            //    },
            //    4 };

            //Console.WriteLine();

            //var tableOfEmployees = objects.OfType<Employee>().ToArray();

            //Console.WriteLine("Zastosowanie metody OfType<Employee> zwróci tablicę tylko obiektów typu Employee:");
            //foreach (var emp in tableOfEmployees)
            //{
            //    Console.WriteLine($"{emp.Name}, {emp.Surname}");
            //}

            //Console.WriteLine("Zastosowanie metody Cast<Employee> zwróci wyjątek - nie wszystkie elementy tablicy objects są typu Employee - wciśnij ENTER");
            //Console.ReadLine();
            //var zwrociWyjatek = objects.Cast<Employee>().ToArray();
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

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}