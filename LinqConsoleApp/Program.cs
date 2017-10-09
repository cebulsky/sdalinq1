using System;
using System.Collections.Generic;
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
            GetTop5LargestFileUsingLinq(path);
            Console.ReadLine();
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