using System;

class ReverseNumber
{
    // // 1 way
    // static int Sum = 0;

    static void Main(string[] args)
    {
        Console.WriteLine(FunReverseNumber(9632));
    }

    // static void FunReverseNumber(int number)
    // {
    //     if (number == 0)
    //         return;
    //     Sum = (Sum * 10) + (number % 10);
    //     FunReverseNumber(number / 10);
    // }

    static int FunReverseNumber(int number)
    {
        int digits = (int)Math.Log10(number) + 1;
        return FunReverseNumber(number, digits);
    }

    static int FunReverseNumber(int number, int digits)
    {
        if (number == 0)
            return 0;
        return (number % 10) * (int)Math.Pow(10, digits - 1) + FunReverseNumber(number / 10, --digits);
    }
}