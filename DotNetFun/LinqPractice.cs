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
        //Examples of using Func & Action with lamda
        public static Func<int, int> square = x => x * x;
        public static Func<int,int,int> add = (x ,y) => x + y;
        public static Action<int> write = x => System.Console.WriteLine(x);
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
    }

}
