using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using TwistedFizzBuzz.Library;

namespace TwistedFizzBuzz.Tests
{
    public class TwistedFizzBuzzTests
    {
        Mock<ITwistedFizzBuzz> twistedFizzBuzzMock;

        [SetUp]
        public void Setup()
        {
            twistedFizzBuzzMock = new Mock<ITwistedFizzBuzz>();
        }

        [Test]
        public void TestGetFizzBuzzOutputWithDefaultDivisors()
        {
            TwistedFizzBuzz.Library.TwistedFizzBuzz fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz();
            string output = fizzBuzz.GetFizzBuzzOutput(1, 15);
            string expectedOutput = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz";
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TestGetFizzBuzzOutputWithCustomDivisors()
        {
            TwistedFizzBuzz.Library.TwistedFizzBuzz fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz(2, 3, "Two", "Three");
            string output = fizzBuzz.GetFizzBuzzOutput(1, 6);
            string expectedOutput = "1 Two Three Two 5 TwoThree";
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TestGetFizzBuzzOutputWithCustomTokens()
        {
            Dictionary<int, string> tokens = new Dictionary<int, string>();
            tokens.Add(2, "Fizz");
            tokens.Add(3, "Buzz");
            TwistedFizzBuzz.Library.TwistedFizzBuzz fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz();
            string output = fizzBuzz.GetFizzBuzzOutput(1, 6, tokens);
            string expectedOutput = "1 Fizz Buzz Fizz 5 FizzBuzz";
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public async Task TestGetFizzBuzzTokensFromAPIAsync()
        {
            string expectedOutput = "FizzBuzz";
            // Arrange
            twistedFizzBuzzMock.Setup(a => a.GetFizzBuzzTokensFromAPIAsync(1, 1000, "https://rich-red-cocoon-veil.cyclic.app/random")).Returns(Task.FromResult(expectedOutput));

            // Act
            var output = await twistedFizzBuzzMock.Object.GetFizzBuzzTokensFromAPIAsync(1, 1000, "https://rich-red-cocoon-veil.cyclic.app/random");

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void TestGet_20_127_Output()
        {
            Dictionary<int, string> tokens = new Dictionary<int, string> { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } };

            TwistedFizzBuzz.Library.TwistedFizzBuzz fizzBuzz = new TwistedFizzBuzz.Library.TwistedFizzBuzz();
            string output = fizzBuzz.GetFizzBuzzOutput(-20, 127, tokens);
            string expectedOutput = "Fizz -19 Buzz -17 -16 Fizz -14 -13 -12 -11 Fizz Buzz -8 -7 -6 Fizz -4 -3 -2 -1 FizzBuzzBar 1 2 3 4 Fizz 6 7 8 Buzz Fizz 11 12 13 14 Fizz 16 17 Buzz 19 Fizz 21 22 23 24 Fizz 26 BuzzBar 28 29 Fizz 31 32 33 34 Fizz Buzz 37 38 39 Fizz 41 42 43 44 FizzBuzz 46 47 48 49 Fizz 51 52 53 BuzzBar Fizz 56 57 58 59 Fizz 61 62 Buzz 64 Fizz 66 67 68 69 Fizz 71 Buzz 73 74 Fizz 76 77 78 79 Fizz BuzzBar 82 83 84 Fizz 86 87 88 89 FizzBuzz 91 92 93 94 Fizz 96 97 98 Buzz Fizz 101 102 103 104 Fizz 106 107 BuzzBar 109 Fizz 111 112 113 114 Fizz 116 Buzz 118 119 Fizz 121 122 123 124 Fizz Buzz 127";
            Assert.AreEqual(expectedOutput, output);
        }
    }
}