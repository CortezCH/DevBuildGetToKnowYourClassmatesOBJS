using System;
using System.Collections.Generic;
using System.Text;

namespace GetToKnowYourClassmatesObjects
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string hometown;
        private string favoriteFood;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Hometown
        {
            get { return hometown; }
            set { hometown = value; }
        }
        public string FavoriteFood
        {
            get { return favoriteFood; }
            set { favoriteFood = value; }
        }

        public Student(string fName, string lName, string home, string food)
        {
            FirstName = fName;
            LastName = lName;
            Hometown = home;
            FavoriteFood = food;
        }

        public void PrintHometown()
        {
            Console.WriteLine($"{FullName()} is from {Hometown}");
        }

        public void PrintFavFood()
        {
            Console.WriteLine($"{FullName()}'s favorite food is {FavoriteFood}");
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public void Getinfo(int index)
        {
            Console.Write($"Student {index+1} is {FullName()}. What would you like to know about {FirstName}?\n" +
                $"(1) Hometown (2) Favorite Food: ");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    PrintHometown();
                    break;
                case "2":
                    PrintFavFood();
                    break;
                default:
                    Console.WriteLine("That input is invalid please try again.");
                    Getinfo(index);
                    break;

            }
        }

    }
}
