using Newtonsoft.Json;

namespace TwistedFizzBuzz.Library
{
    public class TwistedFizzBuzz : ITwistedFizzBuzz
    {
        private readonly int _fizzDivisor;
        private readonly int _buzzDivisor;
        private readonly string _fizzToken;
        private readonly string _buzzToken;

        public TwistedFizzBuzz(int fizzDivisor = 3, int buzzDivisor = 5, string fizzToken = "Fizz", string buzzToken = "Buzz")
        {
            _fizzDivisor = fizzDivisor;
            _buzzDivisor = buzzDivisor;
            _fizzToken = fizzToken;
            _buzzToken = buzzToken;
        }

        public async Task<string> GetFizzBuzzTokensFromAPIAsync(int start, int end, string apiEndpoint)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(apiEndpoint);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var apiTokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);

                var multiple = Convert.ToInt32(apiTokens.Where(a => a.Key == "multiple").SingleOrDefault().Value);
                var word = apiTokens.Where(a => a.Key == "word").SingleOrDefault().Value;

                Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
                keyValuePairs.Add(multiple, word);

                return GetFizzBuzzOutput(start, end, keyValuePairs);
            }
            catch (Exception ex)
            {

            }

            return "";
        }

        public string GetFizzBuzzOutput(IEnumerable<int> numbers)
        {
            var result = "";

            foreach (var number in numbers)
            {
                if (number % _fizzDivisor == 0 && number % _buzzDivisor == 0)
                {
                    result += _fizzToken + _buzzToken;
                }
                else if (number % _fizzDivisor == 0)
                {
                    result += _fizzToken;
                }
                else if (number % _buzzDivisor == 0)
                {
                    result += _buzzToken;
                }
                else
                {
                    result += number.ToString();
                }

                result += " ";
            }

            return result.TrimEnd();
        }

        public string GetFizzBuzzOutput(int start, int end)
        {
            var numbers = Enumerable.Range(start, end - start + 1);
            return GetFizzBuzzOutput(numbers);
        }

        public string GetFizzBuzzOutput(params int[] numbers)
        {
            return GetFizzBuzzOutput(numbers.ToList());
        }

        public string GetFizzBuzzOutput(Dictionary<int, string> tokens)
        {
            var result = "";

            foreach (var pair in tokens.OrderBy(pair => pair.Key))
            {
                var number = pair.Key;
                var token = pair.Value;

                if (number % _fizzDivisor == 0 && number % _buzzDivisor == 0)
                {
                    result += _fizzToken + _buzzToken;
                }
                else if (number % _fizzDivisor == 0)
                {
                    result += _fizzToken;
                }
                else if (number % _buzzDivisor == 0)
                {
                    result += _buzzToken;
                }
                else
                {
                    result += token;
                }

                result += " ";
            }

            return result.TrimEnd();
        }

        public string GetFizzBuzzOutput(int start, int end, Dictionary<int, string> tokens)
        {
            var result = "";
            for (int i = start; i <= end; i++)
            {
                string output = "";

                foreach (KeyValuePair<int, string> divisor in tokens)
                {
                    if (i % divisor.Key == 0)
                    {
                        output += tokens[divisor.Key];
                    }
                }

                result += output == "" ? i.ToString() : output;
                result += " ";
            }

            return result.TrimEnd();
        }
    }
}
