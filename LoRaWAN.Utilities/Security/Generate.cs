using System;
using System.Collections.Generic;
using System.Linq;
using LoRaWAN.Utilities.Models;

namespace LoRaWAN.Utilities.Security
{
    public static class Generate
    {
        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string RandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public static string AlphaNumericPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,                
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789"                  // digits
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);            

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        public static string RandomDigitPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 6
            };

            string[] randomChars = new[] { "0123456789" };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            for (int i = chars.Count; i < opts.RequiredLength; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public static List<string> CardAliasNumber(int count)
        {
            List<string> cards = new List<string>();

            do
            {
                List<int> numbers = new List<int>() { 8, 7, 3, 4, 2, 9 };
                do
                {
                    Random rand = new Random();
                    var item = rand.Next(0, 9);

                    if (numbers.Count < 15)
                    {
                        if (numbers.Sum() <= 120)
                            numbers.Add(item);
                    }
                    else if (numbers.Count == 15)
                    {
                        var mod = numbers.Sum() % 10;
                        if (mod == 0)
                            numbers.Add(0);
                        else
                            numbers.Add(10 - mod);
                    }

                }
                while (numbers.Count != 16);

                if (CalculateLuhnCheckDigit(numbers) == 0)
                {
                    var cardnumber = string.Join("", numbers);
                    if (!cards.Any(x => x == cardnumber))
                    {
                        cards.Add(cardnumber);
                    }
                }
            }
            while (cards.Count != count);

            return cards;
        }
        public static int CalculateLuhnCheckDigit(List<int> digits)
        {
            int sum = 0;
            bool isMultiplyByTwo = false;

            //Start the summing going right to left
            for (int index = digits.Count - 1; index >= 0; --index)
            {
                int digit = digits[index];

                //Every other digit should be multipled by two.
                if (isMultiplyByTwo)
                    digit *= 2;

                //When the digit becomes 2 digits (due to digit*2),
                //we add the two digits together.
                if (digit > 9)
                    digit = digit.ToString()
                      .Sum(character => (int)char.GetNumericValue(character));

                sum += digit;
                isMultiplyByTwo = !isMultiplyByTwo;
            }

            int remainder = sum % 10;

            //If theres no remainder, the checkDigit is 0.
            int checkDigit = 0;

            //Otherwise, the checkDigit is the number that gets to the next 10
            if (remainder != 0)
                checkDigit = 10 - (sum % 10);

            return checkDigit;
        }

    }
}
