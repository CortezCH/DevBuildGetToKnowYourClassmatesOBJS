using System;
using System.Collections.Generic;

namespace GetToKnowYourClassmatesObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Studen Information Center.");
            string choice = string.Empty;
            int index = 0;

            List<Student> students = new List<Student>();
            students.Add(new Student("Erin", "Walter", "Troy, MI", "Tacos"));
            students.Add(new Student("Ricahrd", "Moss", "Canton, MI", "Sushi"));
            students.Add(new Student("James", "Michell", "Yap, FSM", "Katsu"));
            students.Add(new Student("Cullin", "Flynn", "Fowlerville, MI", "Pad Thai"));
            students.Add(new Student("Corrdero", "Ebberhart", "Berklet, MI", "BBQ"));
            students.Add(new Student("Calyn", "Green", "Portage, MI", "Mac and Cheese"));
            students.Add(new Student("Huy", "Phan", "Lansing, MI", "Korean BBQ"));
            students.Add(new Student("Tommy", "Waalkes", "Raleigh, MI", "Chicken Curry"));
            students.Add(new Student("Cassly", "Sullen", "Detroit, MI", "Steak"));
            students.Add(new Student("Phillip", "Conrad", "Canton, MI", "Fried Chicken"));

            //Create a while loop to keep program going
            bool keepGoing = true;

            while (keepGoing)
            {

                DisplayClass(students);

                //ask the user how they would like to search
                choice = NameOrNumber();

                if (choice == "name")
                {
                    //if they answer by name, ask them to enter the name
                    //  search through the list of names for a match
                    //  If no match is found, send them back to search criteria menu
                    string studentName = GetUserInput("Please enter the student's full name: ");
                    index = SearchByName(students, studentName);
                }
                else if (choice == "number")
                {
                    //if they answer by number, ask them for the student number.
                    //  make sure the student number isn't greater than the amount of students in class
                    //  if number is in range, search for the index that the student is in.
                    try
                    {
                        int studentNum = int.Parse(GetUserInput("Please enter the student's ID: "));
                        index = SearchByNumber(students, studentNum-1);
                    }
                    catch
                    {
                        Console.WriteLine("Please only enter numbers.");
                        break;
                    }
                    
                }
                try
                {
                    students[index].Getinfo(index);
                }
                catch
                {
                    Console.WriteLine("That student doesn't exist. Please check your spelling and try again.");
                }

                //Call Continue method to decide if the loop stops or not
                keepGoing = Continue();
            }
        }

        public static string NameOrNumber()
        {
            string nameOrNum = GetUserInput("Please enter what you would like to search a student by " +
                    "(1) Name or (2) Student Number: ").Trim();

            switch (nameOrNum)
            {
                case "1":
                    return "name";
                case "2":
                    return "number";
                default:
                    Console.WriteLine("That input was not valid. Try again");
                    return NameOrNumber();
            }
        }

        public static int SearchByName(List<Student> roster, string name)
        {
            foreach(Student student in roster)
            {
                if (student.FullName().ToLower() == name)
                {
                    return roster.IndexOf(student);
                }
            }

            return -1;
        }

        public static int SearchByNumber(List<Student> roster, int num)
        {
            foreach (Student student in roster)
            {
                if (roster.IndexOf(student) == num)
                {
                    return roster.IndexOf(student);
                }
            }

            return -1;
        }

        public static void DisplayClass(List<Student> roster)
        {
            Console.WriteLine("{0,-16}{1,-20}", "Student Number", "Student Name");
            Console.WriteLine("{0,-16}{1,-20}", "--------------", "------------");
            foreach (Student student in roster)
            {
                Console.WriteLine("{0,-16}{1,-20}", roster.IndexOf(student)+1, student.FirstName + " " + student.LastName);
                //Console.WriteLine($"{roster.IndexOf(student)}\t{student.FirstName} {student.LastName}");
            }
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();


            return output;
        }

        public static bool Continue()
        {
            string answer = GetUserInput("Would you like to know more? (enter “yes” or “no”): ");

            if (answer.ToLower().Trim() == "yes")
            {
                return true;
            }
            else if (answer.ToLower().Trim() == "no")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("Please enter either yes or no to continue.");
                return Continue();
            }

        }
    }
}
