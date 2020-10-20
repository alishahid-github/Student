
using System;

namespace Student
{
    class Student
    {
        public Student()       //Default Constructor
        {
            this.studentName = "Not Initalized";
            this.registrationNumber = "Not Initalized";
            this.CNIC = "Not Initalized";
            this.dateOfBirth = DateTime.MinValue;
            this.CGPA = 0.0;
            this.hobbies = null;
        }

       public  Student(string name, string number)       //Paramertize Constructor taking name and registration num. of the student.
        {
            this.studentName = name;
            this.registrationNumber = number;
            this.CNIC = "Not Initalized";
            this.dateOfBirth = DateTime.MinValue;
            this.CGPA = 0.0;
            this.hobbies = null;
        }

        //data memebers | properties of 6 data Memebers
        public string studentName { get; set; }
        public string registrationNumber { get; set; }
        public string CNIC { get; set; }
        public DateTime dateOfBirth { get; set; }
        public double CGPA { get; set; }
        public string[] hobbies { get; set; }

        //functions for validation
        private bool validate_name(string name)
        {
            foreach (var item in name)      //checking the validation for name
            {
                if (!((item >= 'A' && item <= 'Z') || (item >= 'a' && item <= 'z') || (item == ' ')))
                {
                    Console.WriteLine("Name should be alphabetic. Speciall charecter or numbers are not allowed");
                    return false;
                }

            }
            return true;
        }

        private bool validate_number(string rNumber)
        {

            if (rNumber.Length > 11)    //checking the validation for registration number
            {
                Console.WriteLine("Length is greater than allowed");
                return false;
            }

            if (rNumber.Length == 11)               //checking the validation for registration number
            {
                for (int i = 0; i < rNumber.Length; i++)
                {
                    if (!((rNumber[0] >= '0' && rNumber[0] <= '9') && (rNumber[1] >= '0' && rNumber[1] <= '9') &&
                        (rNumber[2] >= '0' && rNumber[2] <= '9') && (rNumber[3] >= '0' && rNumber[3] <= '9') &&
                        (rNumber[4] == '-') && (rNumber[5] >= 'A' && rNumber[5] <= 'Z') &&
                        (rNumber[6] >= 'A' && rNumber[6] <= 'Z') && (rNumber[7] == '-') &&
                        (rNumber[8] >= '0' && rNumber[8] <= '9') && (rNumber[9] >= '0' && rNumber[9] <= '9') &&
                        (rNumber[10] >= '0' && rNumber[10] <= '9')
                        ))
                    {
                        Console.WriteLine("Number should be like 2018-CS-000. ");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Number should be like 2018-CS-000. ");
                return false;
            }

            return true;
        }

        private bool validate_cnic(string cnic)
        {

            if (cnic.Length != 13)              //checking the validation for CNIC
            {
                Console.WriteLine("CNIC must be 13 digits");
                return false;
            }

            foreach (var item in cnic)
            {
                if (!(item >= '0' && item <= '9'))
                {
                    Console.WriteLine("only Numbers are allowed");
                    return false;
                }

            }
            return true;
        }

        private bool validate_dob(DateTime d)
        {
            if (!(d.Year > 1990 && d.Year < 2005))              //checking the validation for DOB
            {
                Console.WriteLine("Date of birth should be less than 1st January 2005 and greater than 31st December 1990");
                return false;
            }

            return true;

        }

        private bool validate_cgpa(double cgpa)
        {
            if (!(cgpa >= 0.0 && cgpa <= 4.0))                  //checking the validation for CGPA
            {
                Console.WriteLine("cgpa must be between 0-4");
                return false;
            }
            return true;
        }
        public void Input()           // method for taking input from users and save into the object
        {
            string name, rNumber, cnic;
            DateTime dob;
            double cgpa;
            string[] hobbies;
            bool correct;       //loop for taking again input untill correct is not found
            do
            {
                Console.Write("Enter Name of Student: ");
                name = Console.ReadLine();
                correct= validate_name(name);
                if (!correct)
                    Console.WriteLine("Invalid Student Name");
            } while (!correct);

            this.studentName = name;

            do
            {
                Console.Write("Enter Registration Number of Student: ");
                rNumber = Console.ReadLine(); 
                correct = validate_number(rNumber);
                if (!correct)
                    Console.WriteLine("Invalid Registration NUmber");
            } while (!correct);

            this.registrationNumber = rNumber;

            do
            {
                Console.Write("Enter CNIC of Student: ");
                cnic = Console.ReadLine(); 
                correct = validate_cnic(cnic);
                if (!correct)
                    Console.WriteLine("Invalid CNIC ");
            } while (!correct);

            this.CNIC = cnic;

            do
            {
                Console.Write("Enter Student Date of Birth(mm/dd/yyyy): ");
                try
                {
                    dob = Convert.ToDateTime(Console.ReadLine());
                    correct = validate_dob(dob);
                    if (!correct)
                        Console.WriteLine("Invalid Date Of Birth");
                    else
                        this.dateOfBirth = dob;
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid date");
                    correct = false;
                }         
               
            } while (!correct);
            

            do
            {
                Console.Write("Enter CGPA of Student: ");
                cgpa = Convert.ToDouble(Console.ReadLine());
                correct = validate_cgpa(cgpa);
                if (!correct)
                    Console.WriteLine("Invalid CGPA");
            } while (!correct);
            this.CGPA = cgpa;

            Console.Write("How many hobbies you want to enter: ");
            int n = Convert.ToInt32(Console.ReadLine());

            hobbies = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Hobbie number " + i + " of Student: ");
                hobbies[i] = Console.ReadLine();

            }
            this.hobbies = hobbies;

            Console.WriteLine("You input has successfully inserted!" + Environment.NewLine);
            Console.WriteLine();
            
        }

        public string Get_Age()     //this function will calculate the age
        {
            DateTime n = DateTime.Now;
            DateTime d = this.dateOfBirth;

            TimeSpan ts = n - d;            // first, subtracting the current days from birthday and finding the timespan of that, 
            DateTime Age = DateTime.MinValue.AddDays(ts.Days);        //then adding the span to the starting date (01/01/0001) and then finalyy minus one the additional span  
            return " Age is " + Convert.ToString(Age.Year - 1) + " Years " + Convert.ToString(Age.Month - 1) + " " +
                "Month[s] and " + Convert.ToString(Age.Day - 1) + " Day[s]. ";
        }   

        public string Get_Status()          // function to find the Status by the CGPA
        {
            if (this.CGPA < 2.0)
                return "Suspended";
            else if (this.CGPA >= 2.0 && this.CGPA < 2.5)
                return "Below Average";
            else if (this.CGPA >= 2.5 && this.CGPA < 3.3)
                return "Average";
            else if (this.CGPA >= 3.3 && this.CGPA < 3.5)
                return "Below Good";
            else if (this.CGPA >= 3.5)
                return "Excellent";
            else
                return "";

        }

        public int numberOfWordsInName()        //funcition to check how many words in name
        {
            string[] name = this.studentName.Split(' ');

            return name.Length;
        }

        public string Get_Gender()          //function to find male or female base on the last digit is even or not
        {
            if (Convert.ToInt32(this.CNIC[CNIC.Length - 1]) % 2 == 0)
                return "Female";
            else 
                return "Male";
        }

        public string toString()            //function to display the data in full form
        {

            string result = String.Format("Name: {0} ( Contain {1} words[s])\n" +
                                         "Registration Number: {2}\n" +
                                         "CGPA: {3} {4}\n" +
                                         "Date of Birth: {5} ( {6} )\n" +
                                         "CNIC: {7}\n" +
                                         "Gender: {8}\n"
                                         , this.studentName, this.numberOfWordsInName(), this.registrationNumber, this.CGPA
                                         , this.Get_Status(), this.dateOfBirth.ToString("MMMM dd,  yyyy"), this.Get_Age(), this.CNIC, this.Get_Gender());

            result += "Hobbies: ";

            foreach (var item in hobbies)
            {
                result += item + ' ';
            }


            return result;
        }

        public void display()           //function to display the data
        {
            try
            {
                Console.WriteLine("Initialized data is: \nName: {0} \n" +
                                        "Registration Number: {1}\n" +
                                        "CGPA: {2}\n" +
                                        "Date of Birth: {3} \n" +
                                        "CNIC: {4}\n" 
                                        , this.studentName, this.registrationNumber, this.CGPA
                                        , this.dateOfBirth.ToString("MMMM dd,  yyyy"), this.CNIC);

                Console.Write("Hobbies: ");

                foreach (var item in hobbies)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not intialized");
            }
           
        }
        ~Student()          //destructor
        {
            Console.WriteLine("Destructor called");
        }
       
    }
}
