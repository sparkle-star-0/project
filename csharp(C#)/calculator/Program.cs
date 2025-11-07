using System.Numerics;

namespace projects
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int firstnum, secondnum, thirdnum = 0 ;
            string qustion;
            char chk;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("please enter your numbers :");
                firstnum = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("next : ");
                secondnum = int.Parse(Console.ReadLine() ?? "");
                
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("need more ??(y or n)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'y')
                    {
                        Console.WriteLine("enter your number ");
                        thirdnum = int.Parse(Console.ReadLine() ?? "");
                        break;
                    }
                    else if (chk == 'n')
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;      Console.WriteLine("your input incorrect!!");
                }


                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("What mathematical operators do you need?(Multiplication or Sum or Subtraction or Division)");
                    qustion = Console.ReadLine()??"";
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (qustion.StartsWith("multi"))
                    {
                        Console.WriteLine(Multiplication(firstnum, secondnum, thirdnum ));
                        break;
                    }
                    else if (qustion is "sum")
                    {
                        Console.WriteLine(Sum(firstnum, secondnum, thirdnum ));
                        break;
                    }
                    else if (qustion.StartsWith(("subt")))
                    {
                        Console.WriteLine(Subtraction(firstnum, secondnum, thirdnum ));
                        break;
                    }
                    else if (qustion.StartsWith("div"))
                    {
                        if (secondnum == 0)
                        {
                            Console.WriteLine(" warning : some number is zero! ");
                        }
                        else
                            Console.WriteLine(Division(firstnum, secondnum, thirdnum ));
                        break;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;    Console.WriteLine("your input incorrect!!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                while(true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Check divisibility by 5?(y or n , two number has check)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'n')
                        break;
                    else if (chk == 'y')
                    {
                        if (divisibility5(firstnum) && divisibility5(secondnum))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("your first number and second number divisibility by 5");
                            break;
                        }

                        else if (divisibility5(firstnum))
                        {
                            Console.WriteLine("your first number divisibility by 5");
                            break;
                        }
                        else if (divisibility5(secondnum))
                        {
                            Console.WriteLine("your second number is divisibility by 5");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("your number is not divisibility by 5");
                            break;
                        }

                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine("your input incorrect!!");
                }

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Should the prime number be checked?(y or n , two number has check)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'n')
                        break;
                    else if (chk == 'y')
                    {
                        if (isprime(firstnum) && isprime(secondnum))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("your first number and second number is prime");
                            break;
                        }

                        else if (isprime(firstnum))
                        {
                            Console.WriteLine("your first number is prime");
                            break;
                        }
                        else if (isprime(secondnum))
                        {
                            Console.WriteLine("your second number is prime");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("your number is not prime");
                            break;
                        }

                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("your input incorrect!!");
                }


                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" any more ??(y or n)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'y')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("ok ");
                        break;
                    }


                    else if (chk == 'n')
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("your input is not correct");
                }

                if (chk == 'n')
                    break;
                
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("have nice time :) , press enter for exit app");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
        /// <summary>
        /// this function is sum two (or more)numbers
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <returns> this function is return one result </returns>

        static int Multiplication(int num1 , int num2 , int num3 = 1)
        {
            num3 = 1;
            int result;
            result = num1 * num2 * num3;
            return result;
        }
        static int Sum(int num1, int num2, int num3 = 0)
        {
            num3 = 0;
            int result;
            result = num1 + num2 + num3;
            return result;
        }
        static int Subtraction(int num1 , int num2 , int num3 = 0)
        {
            num3 = 0;
            int result;
            result = num1 - num2 - num3;
            return result;
        }
        static int Division(int num1 , int num2 , int num3 = 1)
        { 
            int result;
            result = num1 / num2 / num3;
            return result;
        }
        static bool divisibility5(int num)
        {
            int result;

            result = num % 5;
            if (result == 0)
                return true;
            else
                return false;
        }
        static bool isprime(int num)
        { 
            if (num <= 1)
                    return false;

            if (num == 2)
                    return true;

            if (num % 2 == 0)
                    return false;

            for (int i = 3; i <= num / 2; i += 2)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
            
        }

    }



    
}
