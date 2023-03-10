
using System.Threading.Tasks.Sources;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers == "") return 0;
        var delimiter = ",";
        if (numbers.StartsWith("//"))
        {
            delimiter = numbers[2].ToString();
            numbers = numbers.Substring(4);
        }
        var sum = 0;
        numbers = numbers.Replace("\n", delimiter);
        var numberList = numbers.Split(delimiter);
        foreach (var number in numberList)
        {
            sum += int.Parse(number);
        }
        return sum;
    }
}
