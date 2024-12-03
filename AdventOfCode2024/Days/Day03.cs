
namespace AdventOfCode2024.Days;

internal class Day03 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long result = 0;

        var lines = GetInputLines();

        var list = new List<string>();

        var enabled = true;

        foreach (var line in lines)
        {
            for (int i = 0; i < line.Length - 4; i++)
            {
                if (enabled && line.Substring(i, 7) == @"don't()")
                {
                    enabled = false;
                }

                if (!enabled && line.Substring(i, 4) == "do()")
                {
                    enabled = true;
                }

                if (enabled
                    && line.Substring(i, 4) == "mul("
                    && line[i + 4] != ',')
                {
                    i += 4;
                    var numb1 = 0;
                    var count = 0;
                    while (IsNumber(line[i]))
                    {
                        numb1 = (numb1 * 10) + (line[i] - '0');
                        count++;
                        i++;
                    }

                    if (count == 0 || line[i] != ',')
                    {
                        continue;
                    }

                    i++;

                    var numb2 = 0; var count2 = 0;
                    while (IsNumber(line[i]))
                    {
                        numb2 = (numb2 * 10) + (line[i] - '0');
                        count2++;
                        i++;
                    }

                    if (line[i] == ')')
                    {
                        result += numb1 * numb2;
                    }
                }
            }
        }

        Result(result);
    }

    private bool IsNumber(char v)
    {
        return v >= '0' && v <= '9';
    }
}
