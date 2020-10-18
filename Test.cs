using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student
{
    class Test
    {
        static void Main(string[] args)
        {
            
            Student s1 = new Student("ALi SHahid", "2018-CS-111");
          
            if (s1.Input())
                Console.WriteLine(s1.toString());

            Console.WriteLine("\n\n\n----------------------------------------------------\n\n\n");

            Student s2= new Student();

            if (s1.Input())
                Console.WriteLine(s1.toString());

            Console.WriteLine("Program Ended");
            Console.Read();


        }
    }
}
