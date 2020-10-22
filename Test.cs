//test file of student class

using System;

namespace Student
{
    class Test
    {
        static void Main(string[] args)
        {            
            Student s1 = new Student();     //object with default constructor
            Student s2 = new Student("Name", "2020-SE-645"); //object with parameters

            s1.display();
            Console.WriteLine("");
            s2.display();

            Console.WriteLine("Taking input of student 1:");
            s1.Input();         //taking input
            Console.WriteLine(s1.toString());      

            Console.WriteLine("\n\n\n----------------------------------------------------\n\n\n");
                              
            s2.Input();

            Console.WriteLine(s2.toString());
                        
            Console.WriteLine("\nProgram Ended. Press any key to exit.\n");
            Console.Read();     

        }
    }
}

