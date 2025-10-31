namespace projects
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int firstnum, secondnum, thirdnum ;
            string qustion;
            char chk;
            while (true)
            {

                Console.WriteLine("please enter your numbers :");
                firstnum = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("next : ");
                secondnum = int.Parse(Console.ReadLine() ?? "");
                
                while (true)
                {
                    Console.WriteLine("need more ??(y or n)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'y')
                    {
                        Console.WriteLine("enter your number ");
                        thirdnum = int.Parse(Console.ReadLine()??"");
                        break;
                    }
                    else if (chk == 'n')
                        break;
                    else
                        Console.WriteLine("your input incorrect!!");
                }


                while (true)
                {
                    Console.WriteLine("What mathematical operators do you need?(Multiplication or Sum or Subtraction or Division)");
                    qustion = Console.ReadLine()??"";
                    if (qustion.StartsWith("multi"))
                    {
                        Console.WriteLine(Multiplication(firstnum, secondnum, thirdnum = 1));
                        break;
                    }
                    else if (qustion is "sum")
                    {
                        Console.WriteLine(Sum(firstnum, secondnum, thirdnum = 0));
                        break;
                    }
                    else if (qustion.StartsWith(("subt")))
                    {
                        Console.WriteLine(Subtraction(firstnum, secondnum, thirdnum = 0));
                        break;
                    }
                    else if (qustion.StartsWith("div"))
                    {
                        if (secondnum == 0)
                        {
                            Console.WriteLine(" warning : some number is zero! ");
                        }
                        else
                            Console.WriteLine(Division(firstnum, secondnum, thirdnum = 1));
                        break;
                    }
                    else
                        Console.WriteLine("your input incorrect!!");
                }

                while (true)
                {
                    Console.WriteLine(" any more ??(y or n)");
                    chk = char.Parse(Console.ReadLine() ?? "");
                    if (chk == 'y') 
                    { 
                        Console.WriteLine("ok ");
                        break;
                    }

                    
                    else if (chk == 'n')
                        break;
                    else
                        Console.WriteLine("your input is not correct");
                }

                if (chk == 'n')
                    break;
                
            }
            Console.WriteLine("have nice time :) , press enter for exit app");
            Console.ReadLine();

        }


        static int Multiplication(int num1 , int num2 , int num3 = 1)
        {
            int result;
            result = num1 * num2 * num3;
            return result;
        }
        static int Sum(int num1, int num2, int num3 = 0)
        {
            int result;
            result = num1 + num2 + num3;
            return result;
        }
        static int Subtraction(int num1 , int num2 , int num3 = 0)
        {
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
    }
}
