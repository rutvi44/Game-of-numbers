
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A3MistryR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            // Display the Menu to user which allows to input any of the option
            do
            {
                try
                {                               
                    Console.WriteLine("\nSelect an option and press Enter");
                    Console.WriteLine("1. Display 10 manipulated values");
                    Console.WriteLine("2. Math Game");
                    Console.WriteLine("3. Exit");
                    Console.Write("\nPlease enter your Choice: ");
                    choice = Convert.ToInt16(Console.ReadLine());

                    if (choice > 0 && choice < 4)
                    {
                        if (choice == 1)
                        {
                            ManipulatedNumbers();
                        }
                        else if (choice == 2)
                        {
                            MathGame();
                        }
                        else if (choice == 3)
                        {
                            Console.WriteLine("\nExiting...Have a good day!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("1 to 3 only");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Numerics Only");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too long. Please enter numbers between (1-3)");
                }
            } while (choice != 3);
            Console.ReadKey();
        }
        static void ManipulatedNumbers()
        // Option 1: Program asking the user to enter start number, than program will shows output till 10th number of starting number
        {
            int startNum, answer;
            bool option = false;
            while (!option)
            {
                try
                {
                    Console.Write("\nPlease enter a starting number(Positive number only): ");
                    startNum = Convert.ToInt16(Console.ReadLine());
                    if (startNum < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    for (int i = startNum; i < startNum + 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            answer = i * 3;
                        }
                        else
                        {
                            answer = i * 4;
                        }
                        Console.WriteLine($"{answer}");
                        option = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Numerics only");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("PLease enter positive number");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too long");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any Key to return to main menu");
            Console.ReadKey();
        }
        static void MathGame()
        //Option 2: Program will asks the user to enter an answer of addition which is generated by computer and show the output
        {
            bool keepGoing = true;
            Random random = new Random();
            int num1, num2, computerAnswer, userAnswer;
            string response;

            while (keepGoing)
            {
                num1 = random.Next(1, 10);
                num2 = random.Next(1, 10);
                computerAnswer = num1 + num2;

                bool correct = false;
                bool keepAsking = false;
                while (!correct)
                {
                    try
                    {
                        Console.WriteLine($"\n What is {num1} + {num2} = ? ");
                        Console.Write("Please enter your Answer: ");
                        userAnswer = Convert.ToInt32(Console.ReadLine());

                        if (userAnswer == computerAnswer)
                        {
                            correct = true;
                            Console.WriteLine("\nYou Got it!!");
                            while (!keepAsking)
                            {
                                Console.Write("\n Do you want to play again? (Yes/No): ");
                                response = Console.ReadLine();
                                response = response.ToLower();

                                if (response == "yes" || response == "no")
                                {
                                    keepAsking = true;
                                    if (response == "yes")
                                    {
                                        keepGoing = true;
                                    }
                                    else
                                    {
                                        keepGoing = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter yes or no only");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nPlease try again!!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter numeric value only");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("\nNumber is too long");
                    }
                }

            }
        }
    }
}

