namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            List<int> primes = new List<int>();
            List<int> fibonaccis = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int number = rand.Next(1, 1000);
                numbers.Add(number);
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                if (IsFibonacci(number))
                {
                    fibonaccis.Add(number);
                }
            }
            File.WriteAllLines("primes.txt", primes.Select(n => n.ToString()));
            File.WriteAllLines("fibonaccis.txt", fibonaccis.Select(n => n.ToString()));
            Console.WriteLine($"Generated {numbers.Count}");
            Console.WriteLine($"Found {primes.Count}");
            Console.WriteLine($"Found {fibonaccis.Count}");

            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter the word to search:");
            string searchWord = Console.ReadLine();
            Console.WriteLine("Enter the word to replace:");
            string replaceWord = Console.ReadLine();
            string text = File.ReadAllText(filePath);
            int count = (text.Length - text.Replace(searchWord, "").Length) / searchWord.Length;
            text = text.Replace(searchWord, replaceWord);
            File.WriteAllText(filePath, text);
            Console.WriteLine($"Replaced {count} occurrences of '{searchWord}' with '{replaceWord}'.");

            Console.WriteLine("Enter the path to the text file:");
            string textFilePath = Console.ReadLine();
            Console.WriteLine("Enter the path to the moderation words file:");
            string wordsFilePath = Console.ReadLine();
            string text2 = File.ReadAllText(textFilePath);
            string[] moderationWords = File.ReadAllLines(wordsFilePath);
            foreach (string word in moderationWords)
            {
                text2 = text2.Replace(word, new string('*', word.Length));
            }
            File.WriteAllText(textFilePath, text2);
            Console.WriteLine("Moderation complete.");

            Console.WriteLine("Enter the path to the file:");
            string filePath2 = Console.ReadLine();
            string content = File.ReadAllText(filePath2);
            string reversedContent = new string(content.Reverse().ToArray());
            string newFilePath = "reversed_" + Path.GetFileName(filePath2);
            File.WriteAllText(newFilePath, reversedContent);
            Console.WriteLine($"Content reversed and saved to {newFilePath}.");

            Console.WriteLine("Enter the path to the file:");
            string filePath3 = Console.ReadLine();
            List<int> num = File.ReadAllLines(filePath3).Select(int.Parse).ToList();
            List<int> positiveNumbers = num.Where(n => n > 0).ToList();
            List<int> negativeNumbers = num.Where(n => n < 0).ToList();
            List<int> twoDigitNumbers = num.Where(n => Math.Abs(n) >= 10 && Math.Abs(n) < 100).ToList();
            List<int> fiveDigitNumbers = num.Where(n => Math.Abs(n) >= 10000 && Math.Abs(n) < 100000).ToList();
            Console.WriteLine($"Total numbers: {num.Count}");
            Console.WriteLine($"Positive numbers: {positiveNumbers.Count}");
            Console.WriteLine($"Negative numbers: {negativeNumbers.Count}");
            Console.WriteLine($"Two-digit numbers: {twoDigitNumbers.Count}");
            Console.WriteLine($"Five-digit numbers: {fiveDigitNumbers.Count}");
            File.WriteAllLines("positive_numbers.txt", positiveNumbers.Select(n => n.ToString()));
            File.WriteAllLines("negative_numbers.txt", negativeNumbers.Select(n => n.ToString()));
            File.WriteAllLines("two_digit_numbers.txt", twoDigitNumbers.Select(n => n.ToString()));
            File.WriteAllLines("five_digit_numbers.txt", fiveDigitNumbers.Select(n => n.ToString()));
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static bool IsFibonacci(int number)
        {
            bool IsPerfectSquare(int x)
            {
                int s = (int)Math.Sqrt(x);
                return s * s == x;
            }
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }
    }
}