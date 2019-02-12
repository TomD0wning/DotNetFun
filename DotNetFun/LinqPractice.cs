using System;
using System.Linq;
using System.Collections.Generic;

namespace DotNetFun
{
    public class LinqPractice
    {
        public LinqPractice()
        {
        
        }
        public static void IEnumeratorExample(IEnumerable<Employee> emps)
        {
             IEnumerator<Employee> enumerator =  emps.GetEnumerator();
             while(enumerator.MoveNext()){
                System.Console.WriteLine(enumerator.Current.Name);
             }
        }
        //named method for filtering in where
        public static bool NameStartsWithS(Employee emp){
            return emp.Name.StartsWith('S');
        }
        //anon method for filtering in where
        public static void PrintWhereNameStartsWithS(IEnumerable<Employee> emps){
            foreach (var employee in emps.Where(delegate(Employee employee){
                return employee.Name.StartsWith('S');
            }))
            {
                System.Console.WriteLine(employee.Name);
            }
        }
        //lamda method for filtering in where
        public static void PrintNameUsingLamda(IEnumerable<Employee> emps){
            foreach(var employee in emps.Where(x => x.Name.StartsWith('S'))){
                System.Console.WriteLine(employee.Name);
            }
        }

        public static void FilterMovies(){
                 
        var movies = new List<Movie>{
            new Movie {Title="The Dark Knight", Rating=8.9f,Year=2008},
            new Movie {Title="The Kings Speech", Rating=6.4f,Year=2013},
            new Movie {Title="Commando", Rating=3.5f,Year=1989},
            new Movie {Title="Star Wars IV", Rating=9.9f,Year=1974}
            };

            var query = movies.Filter(m => m.Year > 2000);

            foreach (var movie in query)
            {
             System.Console.WriteLine(movie.Title);   
            }
        }
            //Using an infinate loop from Random, query and take 10 numbers where n > .5
            public static void QueryInfinity(){
                var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
                foreach(var num in numbers){
                    System.Console.WriteLine(num);
                }
        }

        public static void QueryFuelFile(List<Car> cars){

            var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name)
                            .Select(c => c);

            var result = cars.Any(c => c.Manufacturer == "Ford");

             System.Console.WriteLine(result); 
            foreach (var car in query.Take(10))
            {
                System.Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }

        public static void FlattenDataWithSelectMany(List<Car> cars){

            var result = cars.SelectMany(c => c.Name);
    
            foreach (var character in result)
            {
                System.Console.WriteLine(character);
            }
        }

        public static void JoiningDataSets(List<Car> cars, List<Manufacturer> manufacturers){
            
            //Using query syntax
            var query = 
                        from car in cars 
                        join m in manufacturers on car.Manufacturer equals m.Name
                        orderby car.Combined descending, car.Name ascending
                        select new {
                            m.Headquarters,
                            car.Name,
                            car.Combined
                        };

            //using extension method syntax
            var query2 = cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c,m) => new {
                            m.Headquarters,
                            c.Name,
                            c.Combined
                        })
                        .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name);

            foreach (var car in query.Take(10)){
                System.Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
            
            System.Console.WriteLine("\n");

            foreach (var car in query2.Take(10)){
                System.Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
        }

        public static void JoiningDataSetsWithCompositeKey(List<Car> cars, List<Manufacturer> manufacturers){
                        
            //Using query syntax
            var query = 
                        from car in cars 
                        join m in manufacturers on new {car.Manufacturer, car.Year} equals new {Manufacturer = m.Name, m.Year}
                        orderby car.Combined descending, car.Name ascending
                        select new {
                            m.Headquarters,
                            car.Name,
                            car.Combined
                        };

            //using extension method syntax
            var query2 = cars.Join(manufacturers, c => new {c.Manufacturer, c.Year} , m => new {Manufacturer = m.Name, m.Year}, (c,m) => new {
                            m.Headquarters,
                            c.Name,
                            c.Combined
                        })
                        .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name);

            foreach (var car in query.Take(10)){
                System.Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
            
            System.Console.WriteLine("\n");

            foreach (var car in query2.Take(10)){
                System.Console.WriteLine($"{car.Headquarters} {car.Name} {car.Combined}");
            }
        }

        public static void GroupingData(List<Car> cars, List<Manufacturer> manufacturers){
            var query = from car in cars 
                        group car by car.Manufacturer.ToUpper() into m
                        orderby m.Key
                        select m;

            var query2 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                                .OrderBy(g => g.Key);

            foreach (var group in query2)
            {
                System.Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    System.Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }
        }

        public static void GroupJoinData(List<Car> cars, List<Manufacturer> manufacturers){
            
            var query = from m in manufacturers
                        join c in cars on m.Name equals c.Manufacturer
                            into carGroup
                        select new {
                            Manufacturer = m,
                            Cars = carGroup
                        };

            var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, 
                                        (m,g) => new{
                                            Manufacturer = m,
                                            Cars = g
                                            }).OrderBy(m => m.Manufacturer.Name); 

            foreach (var group in query2)
            {
                System.Console.WriteLine($"{group.Manufacturer.Name}: {group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    System.Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }   
        }
            //Find the top three fuel effcient cars by country -
            public static void FuelEffciencyByCountry(List<Car> cars, List<Manufacturer> manufacturers){
            var query = from m in manufacturers
                        join c in cars on m.Name equals c.Manufacturer
                            into carGroup
                        select new {
                            Manufacturer = m,
                            Cars = carGroup
                        } into result //Group the output by headquarters
                        group result by result.Manufacturer.Headquarters;

            var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, 
                                        (m,g) => new{
                                            Manufacturer = m,
                                            Cars = g
                                            }).GroupBy(m => m.Manufacturer.Headquarters); 

            foreach (var group in query2)
            {
                System.Console.WriteLine($"{group.Key}");
                    //Use selectMany to flatten the car group under each manufactuer
                foreach (var car in group.SelectMany(g => g.Cars).OrderByDescending(c => c.Combined).Take(3))
                {
                    System.Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }   
            }
        //Using Linq aggregation features
        public static void Aggregation(List<Car> cars, List<Manufacturer> manufacturers){
            var query = from car in cars
                group car by car.Manufacturer into carGroup
                    select new 
                    { //Linq will loop over the data set 3 times, once for eacg aggregation.
                        Name = carGroup.Key,
                        Max = carGroup.Max(c => c.Combined),
                        Min = carGroup.Min(c => c.Combined),
                        Avg = carGroup.Average(c => c.Combined)
                    };

            foreach (var result in query)
            {
                System.Console.WriteLine($"{result.Name} \n\tMax:{result.Max}, \n\tMin:{result.Min}, \n\tAvg:{result.Avg}");
            }
        }

        //Using the extension methods allows the calculation to be performed once per loop of the dataset
        public static void AggregationUsingExtensionMethods(List<Car> cars, List<Manufacturer> manufacturers){
            var query = cars.GroupBy(c => c.Manufacturer)
                        .Select(g => {
                            var results = g.Aggregate(new CarStatistics(), (acc,c) => acc.Accumulate(c), acc => acc.Compute());
                            return new {
                                Name = g.Key,
                                Max = results.Max,
                                Min = results.Min,
                                Avg = results.Avg

                            };
                        }).OrderByDescending(c => c.Max);

            foreach (var result in query)
            {
                System.Console.WriteLine($"{result.Name} \n\tMax:{result.Max}, \n\tMin:{result.Min}, \n\tAvg:{result.Avg}");
            }
        }

        public static SelectingFoodsFromDB(){
            
        }
        
        //Examples of using Func & Action with lamda   
        public static Func<int, int> square = x => x * x;
        public static Func<int,int,int> add = (x ,y) => x + y;
        public static Action<int> write = x => System.Console.WriteLine(x);
        public static Action<string> eatFood = x => System.Console.WriteLine($"Eating: {x}");
    }

    public class CarStatistics{
        public int Max { get; set; }
        public int Min { get; set; }
        public double Avg { get; set; }
        public int Total { get; set; }
        public int CarCount { get; set; }


        public CarStatistics ()
        {   
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public  CarStatistics Accumulate(Car car){
        Total += car.Combined;
        CarCount+=1;
        Max = Math.Max(Max,car.Combined);
        Min = Math.Min(Min,car.Combined);
            return this;
        }
        public CarStatistics Compute(){
            Avg = Total/CarCount;
            return this;
        }
    }
    public static class MyLinq{
        //Example of creating a generic extension method
        public static int Count<T>(this IEnumerable<T> sequence){
            int count = 0;
            foreach(var item in sequence){
                count+=1;
            }
            return count;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> sourceData, Func<T,bool> predicate){
            
            foreach (var item in sourceData)
            {
                if(predicate(item)){
                    yield return item;
                }                
            }
        }
        //Generates a random infinitly long sequence
        public static IEnumerable<double> Random(){
            var random = new Random();
            while(true){
                yield return random.NextDouble();
            }
        }

        public static IEnumerable<Car> ToCar(this IEnumerable<string> source){
            foreach (var line in source)
            {    
                var cols = line.Split(',');
                    yield return new Car{
                    Year = int.Parse(cols[0]),
                    Manufacturer = cols[1],
                    Name = cols[2],
                    Displacement = double.Parse(cols[3]),
                    Cylinders = int.Parse(cols[4]),
                    City = int.Parse(cols[5]),
                    Highway = int.Parse(cols[6]),
                    Combined = int.Parse(cols[7])
                };
            };
        }
    }
}
