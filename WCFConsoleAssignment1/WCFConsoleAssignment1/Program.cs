using System;
using System.Threading.Tasks;
using ServiceReference1;

namespace WCFConsoleAssignment1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Prime number\n" +
                    "2.Sum of digits\n" +
                    "3.Reverse a string\n" +
                    "4.Print HTML tags\n" +
                    "5.Sort 5 numbers\n" +
                    "6.Exit");
                string selection = Console.ReadLine();
                if (selection.Equals("6")) break;
                else await Menu(selection);
            }
        }

        private static async Task Menu(string selection)
        {
            Service1Client client = new Service1Client();
            string input = "";
            int result = 0;
            switch (selection)
            {
                case "1":
                    {
                        Console.WriteLine("Enter integer to check for Prime");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out result))
                        {
                            IsPrimeRequest isPrime = new IsPrimeRequest(result);
                            var value = await client.IsPrimeAsync(isPrime);
                            IsPrimeResponse primeResponse = value;
                            Console.WriteLine(primeResponse.IsPrimeResult);
                        }
                        else Console.WriteLine("Not an int");
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine("Enter string to sum up all included digits");
                        input = Console.ReadLine();
                        DigitSumRequest digitSum = new DigitSumRequest(input);
                        var value = await client.DigitSumAsync(digitSum);
                        DigitSumResponse digitResponse = value;
                        Console.WriteLine(digitResponse.DigitSumResult);
                    }
                    break;
                case "3":
                    {
                        Console.WriteLine("Enter String to reverse");
                        input = Console.ReadLine();
                        ReverseStringRequest stringRequest = new ReverseStringRequest(input);
                        var value = await client.ReverseStringAsync(stringRequest);
                        ReverseStringResponse stringResponse = value;
                        Console.WriteLine(stringResponse.ReverseStringResult);
                    }
                    break;
                case "4":
                    { 
                        Console.WriteLine("Enter HTML tag");
                        input = Console.ReadLine();
                        Console.WriteLine("Enter HTML tag contents");
                        string content = Console.ReadLine();
                        HTMLBuildRequest buildRequest = new HTMLBuildRequest(input, content);
                        var value = await client.HTMLBuildAsync(buildRequest);
                        HTMLBuildResponse buildResponse = value;
                        Console.WriteLine(buildResponse.HTMLBuildResult);
                    }
                    break;
                case "5":
                    { 
                        Console.WriteLine("Enter Sort Style");
                        input = Console.ReadLine();
                        Console.WriteLine("Enter 5 Numbers to sort");
                        int[] content = new int[5];
                        for (int i = 0; i < content.Length; i++)
                        {
                            if (int.TryParse(Console.ReadLine(),out result))
                            {
                            content[i] = result;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Integer try again");
                                i--;
                            }                            
                        }
                        SortNumbersRequest numbersRequest = new SortNumbersRequest(input, content);
                        var value = await client.SortNumbersAsync(numbersRequest);
                        SortNumbersResponse numbersResponse = value;
                        Console.WriteLine(numbersResponse.SortNumbersResult);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
