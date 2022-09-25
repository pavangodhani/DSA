using System;

class Palindrome
{
    static void Main(string[] args)
    {
        Console.WriteLine(CheckPalindrome(303));
    }

    static bool CheckPalindrome(int number)
    {
        int digits = (int)Math.Log10(number) + 1;
        return number == ReverseANumber(number, digits);
    }

    static int ReverseANumber(int number, int digits)
    {
        if (number == 0)
            return 0;
        return (number % 10) * (int)Math.Pow(10, digits - 1) + ReverseANumber(number / 10, digits - 1);
    }
}