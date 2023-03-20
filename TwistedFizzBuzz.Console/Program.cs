using TwistedFizzBuzz.Library;

namespace TwistedFizzBuzz.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz();

            // Get FizzBuzz output for the range of numbers 1-20
            var fizzBuzzOutput = fizzBuzz.GetFizzBuzzOutput(1, 50);
            Console.WriteLine(fizzBuzzOutput);
            Console.WriteLine("\n");

            // Example 2: Non-sequential set of numbers
            var nonSequenticalOutput = fizzBuzz.GetFizzBuzzOutput(new int[] { -5, 6, 300, 12, 15 });
            Console.WriteLine(nonSequenticalOutput);
            Console.WriteLine("\n");

            // Example 3: Alternative tokens and divisors
            string alternativeTokensDivisors = fizzBuzz.GetFizzBuzzOutput(1,50, new Dictionary<int, string> { { 7, "Poem" }, { 17, "Writer" }, { 3, "College" } });
            Console.WriteLine(alternativeTokensDivisors);
            Console.WriteLine("\n");

            //  Example 4: API endpoint
            var apiEndpoint = "https://rich-red-cocoon-veil.cyclic.app/random";
            var apiEndpointOutput = await fizzBuzz.GetFizzBuzzTokensFromAPIAsync(1,10000, apiEndpoint);
            Console.WriteLine(apiEndpointOutput);
        }

        private void AskUserQuestionsAboutFizzBuzz()
        {
            //initialize menu variables
            bool isValid = false;
            string choice;

            /*get decision if user wants to fizzbuzz, looping
            until a valid input is provided*/
            do
            {
                Console.WriteLine("Would you like to fizzbuzz? [Y]/[N]");
                choice = Console.ReadLine();
                choice = choice.ToLower();  //convert to lowercase
                if (choice == "y" | choice == "n")
                {
                    isValid = true;          //accept input
                }
                else
                {
                    Console.WriteLine("Sorry, input was not valid.");
                }
            }
            while (isValid == false);
            //end of input loop

            //interpret the result of either "y" or "n"
            if (choice == "y")
            {
                FizzBuzz.PrintKeyWords();
            }
            else
            {
                Console.WriteLine("That's ok, have a nice day!");
            }



            Console.ReadLine();
        }
    }
}


