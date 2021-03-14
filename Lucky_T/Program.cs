using System;

namespace Lucky_T
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string playagain;
                int _first, _last;
                bool _again = true;
                bool _isDigits = true;
                bool _isLong = true;
                bool _isLucky = false;

                while (_again)
                {
                    startLoop:
                    Console.WriteLine("Enter choice: ");
                    string _input = Console.ReadLine();
                    _isDigits = isDigitsOnly(_input);
                    _isLong = isLong(_input);
                    if (!_isLong | !_isDigits)
                    {
                        Console.WriteLine("The number have to contain only 4 to 8 digits long.");
                        Console.WriteLine("You want to play again?");
                        Console.WriteLine("Enter 'y' to continue or 'n' to exit");
                        playagain = Console.ReadLine();
                        _again = ToBoolean(playagain);
                        if (!_again) return;
                        goto startLoop;
                    }
                    _input = OddNum(_input);
                    string first_str = _input.Substring(0, (_input.Length / 2));
                    string last_str = _input.Substring((_input.Length / 2), (_input.Length / 2));
                    _first = findSum(first_str);
                    _last = findSum(last_str);
                    _isLucky = isLucky(_first, _last);
                    Console.WriteLine($"The ticket is lucky:{_isLucky}");
                    Console.WriteLine("You want to play again?");
                    Console.WriteLine("Enter 'y' to continue or 'n' to exit");
                    playagain = Console.ReadLine();
                    _again = ToBoolean(playagain);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


        }
        static bool isDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        static bool isLucky(int first, int last)
        {
            if (first == last)
            {
                return true;
            }
            return false;
        }
        static bool isLong(string str)
        {
            if (str.Length >= 4 && str.Length <= 8)
            {
                return true;
            }
            return false;
        }

        static int findSum(string str)
        {

            String temp = "0";

            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if (char.IsDigit(ch))
                    temp += ch;
                sum += int.Parse(temp);
                temp = "0";

            }
            return sum;
        }
        public static bool ToBoolean(string value)
        {
            switch (value.ToLower())
            {
                case "yes":
                    return true;
                case "y":
                    return true;
                case "no":
                    return false;
                case "n":
                    return false;
                default:
                    throw new InvalidCastException("Incorrect value");
            }
        }
        static string OddNum(string str)
        {
            if (str.Length % 2 != 0)
            {
                str = str.Insert(0, "0");
            }
            return str;
        }

    }
}
