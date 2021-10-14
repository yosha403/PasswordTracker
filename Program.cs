using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//DevBuild Lab : Password Tracker
//Author: Yosha Kunnummal
//Date: 10/13/2021
namespace PasswordTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userNames = new List<string>();
            List<string> passWords = new List<string>();

            bool goOn = true;
            while (goOn == true)
            {

                //Enter a username
                Console.Write("Enter a username: ");
                string userName = Console.ReadLine();

                //Validate the username(Check whether this username is following all rules)
                bool validUser = UserNameCheck(userName);

                if (validUser == true)
                {
                    //Enter a password
                    Console.Write("Enter a password: ");
                    string passWord = Console.ReadLine();

                    //Validate the password(Check whether the password is following all rules)
                    bool validPassword = PasswordCheck(passWord);

                    if (validPassword == true)
                    {
                        userNames.Add(userName);
                        passWords.Add(passWord);
                        Console.WriteLine("\nNew user added.");

                        Console.WriteLine("\nUsername\t\tPassword");
                        Console.WriteLine("\n----------\t\t----------");

                        for (int i = 0; i < userNames.Count; i++)
                        {
                            Console.WriteLine($"{userNames[i]}\t\t\t{passWords[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That username doesn't follow the rules!");
                    }
                }
                else
                {
                    Console.WriteLine("That username doesn't follow the rules!");
                }
                goOn = Continue();
            }
        }

        public static bool Continue()
        {
            Console.WriteLine("\nWould you like to add another user ? (enter “yes” or “no”):");
            string answer = Console.ReadLine().ToLower();

            if (answer.ToLower() == "yes")
            {
                return true;
            }
            else if (answer.ToLower() == "no")
            {
                Console.WriteLine("GoodBye!");
                return false;
            }
            else
            {
                Console.WriteLine("\nThis is not a valid selection. ");
                Console.WriteLine("Please try again!");

                //This is recursion, calling a method inside itself
                return Continue();
            }
        }
        public static bool UserNameCheck(string username)
        {
            //check for the length of username
            if (username.Length < 7 || username.Length > 12)
            {
                Console.WriteLine("\nUsername must be a length of 7 character minimum and must be no longer than 12 characters");
                return false;
            }

            //Check for letters and numbers
            else if (!(username.Any(char.IsLetter) && username.Any(char.IsDigit)))
            {
                Console.WriteLine("\nUsername must have letters and numbers");
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool PasswordCheck(string password)
        {
            //check for the length of password
            if (password.Length < 7 || password.Length > 12)
            {
                Console.WriteLine("\nPassword must have minimum 7 characters and maximum 12 characters");
                return false;
            }

            //Check for atleast one number
            else if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("\nPassword must have atleast one number");
                return false;
            }

            //Check for atleast one lowercase letter using a regular expression           
            else if (!Regex.Match(password, "(?=.*[a-z])").Success)
            {
                Console.WriteLine("\nPassword must have atleast one lowercase letter");
                return false;
            }

            //Check for atleast one uppercase letter using a regular expression           
            else if (!Regex.Match(password, "(?=.*[A-Z])").Success)
            {
                Console.WriteLine("\nPassword must have atleast one uppercase letter");
                return false;
            }

            //Check for atleast one special character using a regular expression           
            else if (!Regex.Match(password, "(?=.*[! @ # $ % ^ & *])").Success)
            {
                Console.WriteLine("\nPassword must have atleast one special character like '! @ # $ % ^ & *' ");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
