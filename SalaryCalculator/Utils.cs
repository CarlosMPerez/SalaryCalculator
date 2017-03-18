using System;
using System.Text;

namespace SalaryCalculator
{
    /// <summary>
    /// Utilities class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Writes a warning in red and returns the console to its normal color
        /// </summary>
        /// <param name="msg">the message of warning</param>
        public static void WriteWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Reads the keyboard input and cancels the program
        /// when pressed ESC
        /// </summary>
        /// <returns>A string with all the input, 
        /// if ESC has not been pressed</returns>
        public static string ReadInput()
        {
            string result = null;

            StringBuilder buffer = new StringBuilder();

            //The key is read passing true for the intercept argument to prevent
            //any characters from displaying when the Escape key is pressed.
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                Console.Write(info.KeyChar);
                buffer.Append(info.KeyChar);
                info = Console.ReadKey(true);
            }

            if (info.Key == ConsoleKey.Enter)
            {
                result = buffer.ToString();
            }

            if (result == null) Environment.Exit(0);
            return result;
        }

        /// <summary>
        /// Validates the number of hours entered
        /// </summary>
        /// <param name="input">the input</param>
        /// <returns>False if it's a valid input, true if valid</returns>
        public static bool ValidateHours(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                if (result > 0) return true;
                else
                {
                    Utils.WriteWarning("\n\nThe amount of hours worked has to be bigger than 0.\n");
                    return false;
                }
            }
            else
            {
                Utils.WriteWarning("\n\nThe amount of hours worked has to be an integer value.\n");
                return false;
            }
        }

        /// <summary>
        /// Validates the hourly rate entered
        /// </summary>
        /// <param name="input">the input</param>
        /// <returns>False if invalid, true if valid</returns>
        public static bool ValidateRate(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
            {
                if (result > 0) return true;
                else
                {
                    Utils.WriteWarning("\n\nThe hourly rate has to be bigger than 0.\n");
                    return false;
                }
            }
            else
            {
                Utils.WriteWarning("\n\nThe hourly rate has to be an numeric value.\n");
                return false;
            }
        }

        /// <summary>
        /// Validates the country entered
        /// </summary>
        /// <param name="input">the user input</param>
        /// <returns>False if invalid, true if valid</returns>
        public static bool ValidateCountry(string input)
        {
            int country;

            if (int.TryParse(input, out country))
            {
                if (country < 1 || country > 4)
                {
                    Utils.WriteWarning("\n\nInvalid country option.\n Choose an option between 1 and 4.\n");
                    return false;
                }
                else return true;
            }
            else
            {
                Utils.WriteWarning("\n\nInvalid country option.\n Choose a numeric option.\n");
                return false;
            }
        }
        
        /// <summary>
        /// Formats the amount passed according to the country's culture passed
        /// </summary>
        /// <param name="country"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string FormatToCurrency(string country, decimal amount)
        {
            string cult = "";
            switch (country)
            {
                case "Ireland":
                    cult = "en-IE";
                    break;
                case "Italy":
                    cult = "it-IT";
                    break;
                case "Germany":
                    cult = "de-DE";
                    break;
                case "Cayman Islands":
                    cult = "en-JM";
                    break;
            }

            return string.Format(new System.Globalization.CultureInfo(cult), "{0:C}", amount);
        }
    }
}
