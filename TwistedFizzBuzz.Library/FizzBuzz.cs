namespace TwistedFizzBuzz.Library
{
    public class FizzBuzz
    {
        public static void PrintKeyWords()
        {
            //initialize fizzbuzz input (FBinput*) variables
            int fbinputStart = 0;
            int fbinputE = 0;
            int fbinputF = 0;
            int fbinputB = 0;
            bool validinput = false;

            /*take input for start and end values,
            if start is larger than end ask again*/
            do
            {
                Console.WriteLine("What number would you like to start from?");
                fbinputStart = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What number would you like to end at?");
                fbinputE = Convert.ToInt32(Console.ReadLine());

                if (fbinputStart > fbinputE)
                {   //check of start and end values
                    Console.WriteLine("You choose a starting number larger than your ending number;");
                    Console.WriteLine("please input new values.");
                }
                else
                {
                    validinput = true;    //accept input
                }
            } 
            while (validinput == false);
            //end validation loop

            // Take input for keywords, like 2(Fizz buzz), 3(Poem,Writer,College)
            int numberOfKeywords = 0;
            bool isValidKeywords = false;
            do
            {
                Console.WriteLine("How many keywords you want? like 2(Fizz,buzz), 3(Poem,Writer,College)");
                numberOfKeywords = Convert.ToInt32(Console.ReadLine());

                if (numberOfKeywords > 0)
                {
                    isValidKeywords = true;
                }
            }
            while (isValidKeywords == false);

            Dictionary<string,int> keyWords = new Dictionary<string, int>();
            for (int i = 1; i <= numberOfKeywords; i++)
            {
                Console.WriteLine("Enter keyword for " + i);
                string keyWord = Console.ReadLine();
                if (keyWord.Trim() == string.Empty)
                {
                    Console.WriteLine("Enter valid keyword for " + i);
                    keyWord = Console.ReadLine();
                }

                bool isKeywordNumberValid = false;
                do
                {
                    Console.WriteLine($"What number would you like to {keyWord}?");
                    string keywordNumber = Console.ReadLine();
                    int value;
                    if (int.TryParse(keywordNumber, out value))
                    {
                        isKeywordNumberValid = true;
                        keyWords.Add(keyWord, value);
                    }
                    
                }
                while (isKeywordNumberValid == false);
            }

            //Print
            PrintFizzBuzz(fbinputStart, fbinputE, keyWords);
        }

        static void PrintFizzBuzz(int FBstart, int FBend, Dictionary<string, int> keyWords)
        {
            //initialize the display string
            string c;

            var keyword = string.Join(" ", keyWords.Keys.ToArray());

            Console.WriteLine($"\n{keyword} time!\n");

            //fizzbuzz loop   
            for (int i = FBstart; i <= FBend; i++)
            {
                //set c to blank string    
                c = "";

                foreach (var k in keyWords)
                {
                    if (i % k.Value == 0)
                    {
                        c = c + k.Key;
                    }
                }

                if (c.Length == 0)
                {
                    c = Convert.ToString(i);
                }

                //print display string of number i
                Console.WriteLine(c);
            }
            //end fizzbuzz loop

            Console.WriteLine($"\n{keyword} complete!");
            Console.ReadLine();
        }
    }
}