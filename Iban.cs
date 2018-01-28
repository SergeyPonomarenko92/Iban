using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace IBAN
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^BG[0-9]{2}[A-Z]{4}[0-9]{6}[A-Z0-9]{8}$";

            Console.Write("Input IBAN: ");
            string iban = Console.ReadLine();

            iban = iban.ToUpper(); 
            iban = iban.Replace(" ", ""); 

            if (Regex.IsMatch(iban, pattern))
            {
                
                string beginning = iban.Substring(0, 4); 
                string end = iban.Substring(4, iban.Length - 4);

                iban = end + beginning;

                
                char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                

               
                string numericalIban = "";
                foreach (char c in iban)
                {
                    int index = Array.IndexOf(alphabet, c);
                    numericalIban += index.ToString();
                }

                BigInteger ibanInteger = BigInteger.Parse(numericalIban); // переводим строку numericalIban в число ibanInteger
                BigInteger checksum = ibanInteger % 97; // берем остаток от деления ibanInteger на 97

                if (checksum != 1) Console.WriteLine("Invalid IBAN"); else Console.WriteLine("Valid IBAN checksum");
            }
            else
            {
                // str не соответствует паттерну
                Console.WriteLine("Invalid IBAN pattern");
            }
        }
    }
}
