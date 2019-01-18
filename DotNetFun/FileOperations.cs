using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DotNetFun
{
    public class FileOperations
    {

        public static void ShowLargeFilesWithLinq(string path)
        {
            //As example of getting dir info & files sizes using linq
            // var query = from file in new DirectoryInfo(path).GetFiles()
            //             orderby file.Length descending
            //             select file;

            var query = new DirectoryInfo(path).GetFiles()
                            .OrderByDescending(f => f.Length)
                            .Take(5);

            foreach (var file in query)
            {
                System.Console.WriteLine($"{file.Name, -10}:{file.Length}");
            }
        }
        public static void ShowLargeFiles(string path)
        {
            //As example of getting dir info & files sizes without using linq
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files =  dir.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                System.Console.WriteLine($"{file.Name, -10}:{file.Length}");
            }
        }

        public static List<Car> ProcessFuelFile(string fileName){
            try{
            return File.ReadAllLines(fileName)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToCar()
                .ToList();
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
            }

            return new List<Car>();
        }

        public static List<Manufacturer> ProcessManufacturerFile(string fileName){
            
            try{
                var query = File.ReadAllLines(fileName)
                            .Skip(1)
                            .Where(x => x.Length > 1)
                            .Select(x => {
                                var cols = x.Split(',');
                                return new Manufacturer
                                {
                                    Name = cols[0],
                                    Headquarters = cols[1],
                                    Year = int.Parse(cols[2])
                                };
                            });
                return query.ToList();
            }catch(Exception ex){
                System.Console.WriteLine(ex.Message);
            }
            return new List<Manufacturer>();
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo a, FileInfo b)
        {
            return a.Length.CompareTo(b.Length);
        }
    }
}