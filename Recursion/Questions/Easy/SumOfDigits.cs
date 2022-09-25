using System;

class SumOfDigits
{
    static void Main(string[] args)
    {
        Console.WriteLine(DigitSum(451));
        Console.WriteLine(DigitProduct(451));
    }

    static int DigitSum(int number)
    {
        if(number == 0)
            return 0;

        return number % 10 + (DigitSum(number/10)); 
    }

    static int DigitProduct(int number)
    {
        if(number == 0)
            return 1;

        return (number % 10) * (DigitProduct(number/10)); 
    }
}