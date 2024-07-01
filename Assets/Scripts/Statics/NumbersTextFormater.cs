using System.Numerics;

namespace Scripts.Statics
{
    public static class NumbersTextFormater
    {
        public static string FormatNumber(BigInteger rawNumber)
        {
            if (rawNumber < 1000) return  rawNumber.ToString();

            BigInteger[] numbers = new BigInteger[2];
            
            BigInteger whole;
            BigInteger partial;
            string end = "";
            
            if (rawNumber >= BigInteger.Pow(10, 24))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 24));
                end = "Sx";
            }
            else if (rawNumber >= BigInteger.Pow(10, 21))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 21));
                end = "Qi";
            }
            else if (rawNumber >= BigInteger.Pow(10, 18))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 18));
                end = "Qa";
            }
            else if (rawNumber >= BigInteger.Pow(10, 15))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 15));
                end = "T";
            }
            else if (rawNumber >= BigInteger.Pow(10, 12))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 12));
                end = "B";
            }
            else if (rawNumber >= BigInteger.Pow(10, 9))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 9));
                end = "Mld";
            }
            else if (rawNumber >= BigInteger.Pow(10, 6))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 6));
                end = "Mln";
            }
            else if (rawNumber >= BigInteger.Pow(10, 3))
            {
                numbers = GetNumbers(rawNumber, BigInteger.Pow(10, 3));
                end = "K";
            }
            
            return numbers[0] + "," + numbers[1] + end;
        }

        public static BigInteger[] GetNumbers(BigInteger raw, BigInteger max)
        {
            BigInteger[] numbers = new BigInteger[2];
            numbers[0] = BigInteger.Divide(raw, max);
            numbers[1] = BigInteger.Divide(raw - numbers[0] * max, BigInteger.Divide(max, 100));
            return numbers;
        }
    }
}