
namespace AdventOfCode2024.Days;

internal class Day01 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long result = 0;

        var lines = GetInputLines();
        var parsedInfo = Parse(lines);
        Calculate(parsedInfo);

        Result(result);
    }

    private void Calculate(object parsedInfo)
    {


    }

    private object Parse(string[] lines)
    {

        foreach (var line in lines)
        {
            // Do something...


        }

        return null;
    }
}
