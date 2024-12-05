
namespace AdventOfCode2024.Days;

internal class Day05 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long correctUpdates = 0;
        long reorderedUpdates = 0;

        var lines = GetInputLines();

        var ordering = new List<(int left, int right)>();

        var index = 0;
        for (; index < lines.Length && lines[index] != string.Empty; index++)
        {
            var split = lines[index].Split('|').Select(int.Parse).ToArray();
            ordering.Add((split[0], split[1]));
        }

        var updates = new List<List<int>>();

        index++;
        for (; index < lines.Length; index++)
        {
            updates.Add(lines[index].Split(',').Select(int.Parse).ToList());
        }

        foreach (var update in updates)
        {
            var good = true;
            for (int i = 0; i < update.Count && good; i++)
            {
                var currentNumber = update[i];
                var otherNumbers = ordering.Where(o => o.left == currentNumber).Select(o => o.right).ToArray();

                for (int j = i - 1; j >= 0; j--)
                {
                    if (otherNumbers.Contains(update[j]))
                    {
                        good = false; break;
                    }
                }
            }

            if (good)
            {
                var middle = update.Count / 2;
                correctUpdates += update[middle];
            }
            else
            {
                reorderedUpdates += ReOrder(update, ordering);
            }
        }

        Result(correctUpdates);
        Result(reorderedUpdates);
    }

    private int ReOrder(List<int> update, List<(int left, int right)> ordering)
    {
        for (int i = 0; i < update.Count; i++)
        {
            var currentNumber = update[i];
            var otherNumbers = ordering.Where(o => o.left == currentNumber).Select(o => o.right).ToArray();

            for (int j = i - 1; j >= 0; j--)
            {
                if (otherNumbers.Contains(update[j]))
                {
                    // swap and reset
                    var n2 = update[j];
                    update[i] = n2;
                    update[j] = currentNumber;

                    i = -1;
                    break;
                }
            }

        }

        var middle = update.Count / 2;
        return update[middle];
    }
}
