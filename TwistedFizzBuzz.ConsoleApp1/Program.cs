using TwistedFizzBuzz.Library;

namespace TwistedFizzBuzz.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz();

            int start = -20;
            int end = 127;

            Console.WriteLine($"Range output for {start} to {end}:");            
            string outPut = fizzBuzz.GetFizzBuzzOutput(start, end, new Dictionary<int, string> { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } });
            Console.WriteLine(outPut);
        }
    }
}