namespace AdventOfCode2024.Days;

internal class Day02 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        
        var lines = GetInputLines();
        var parsedInfo = Parse(lines);
        Calculate(parsedInfo);
    }

    private List<int[]> Parse(string[] lines)
    {
        var list = new List<int[]>();

        foreach (var line in lines)
        {
            list.Add(line.Split(" ").Select(int.Parse).ToArray());
        }

        return list;
    }

    private void Calculate(List<int[]> list)
    {
        var safeCountP1 = 0;
        var safeCountP2 = 0;

        foreach (var report in list)
        {
            var span = report.AsSpan();
            var isSafe = CheckSafe(span);
            if (isSafe)
            {
                safeCountP1++;
                continue;
            }

            // Could be smarter about this...
            for (int i = 0; i < span.Length; i++)
            {
                Span<int> secondReport = [.. span[..i], .. span[(i+1)..]];
                isSafe = CheckSafe(secondReport);

                if (isSafe)
                {
                    safeCountP2++;
                    break;
                }
            }
        }

        Result(safeCountP1);
        Result(safeCountP1 + safeCountP2);
    }

    private static bool CheckSafe(Span<int> report)
    {
        bool increase = report[0] < report[1];
        var safe = true;

        for (int i = 0; safe && i < report.Length - 1; i++)
        {
            var diff = report[i] - report[i + 1];

            if ((!increase && diff < 0) 
                || (increase && diff > 0) 
                || Math.Abs(diff) > 3 
                || diff == 0)
            {
                safe = false;
                break;
            }
        }

        if (safe)
        {
            return true;
        }

        return false;
    }
}
