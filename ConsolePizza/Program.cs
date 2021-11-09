using System;
using System.Collections.Generic;

namespace ConsolePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            long members = long.Parse(Console.ReadLine());
            string[] boss = Console.ReadLine().Split(' ');
            List<Employee> empList = new() { new Employee(1, 0) };
            for (long i = 2; i <= members; i++)
            {
                if ((i - 1) <= (long)boss.Length)
                {
                    empList.Add(new Employee(i, long.Parse(boss[i - 2]))); 
                }
                else
                {
                    empList.Add(new Employee(i, 0));
                }
            }
            empList.ForEach(e => e.SetMembers(empList));
            empList.ForEach(e => Console.WriteLine(e.Members.Count.ToString()));

            Console.ReadKey();
        }
    }
}
