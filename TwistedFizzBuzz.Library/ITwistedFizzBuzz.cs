namespace TwistedFizzBuzz.Library
{
    public interface ITwistedFizzBuzz
    {
        Task<string> GetFizzBuzzTokensFromAPIAsync(int start, int end, string apiEndpoint);

        string GetFizzBuzzOutput(IEnumerable<int> numbers);

        string GetFizzBuzzOutput(int start, int end);

        string GetFizzBuzzOutput(params int[] numbers);

        string GetFizzBuzzOutput(Dictionary<int, string> tokens);

        string GetFizzBuzzOutput(int start, int end, Dictionary<int, string> tokens);
    }
}
