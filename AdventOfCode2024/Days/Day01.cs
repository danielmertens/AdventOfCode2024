using System.Diagnostics;

namespace AdventOfCode2024.Days;

internal class Day01 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        
        var lines = GetInputLines();
        
        var stopwatch = Stopwatch.StartNew();
        
        var (left, right) = Parse(lines);
        var (sum, multi) = Calculate(left, right);

        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed.ToString());

        Result(sum);
        Result(multi);
    }

    private (int sum, int multi) Calculate(OrderedList left, OrderedListWithCounts right)
    {
        var sum = 0;
        var multi = 0;

        for (var i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
            var count = right.Occurrence(left[i]);
            multi += left[i] * count;
        }

        return (sum, multi);
    }

    private (OrderedList left, OrderedListWithCounts right) Parse(string[] lines)
    {
        var left = new OrderedList();
        var right = new OrderedListWithCounts();

        for (var i = 0; i < lines.Length; i++)
        {
            var split = lines[i].Split("   ");
            left.Add(ParseIntQuick(split[0]));
            right.Add(ParseIntQuick(split[1]));
        }

        return (left, right);
    }

    private int ParseIntQuick(string text)
    {
        var number = 0;
        for(var i = 0; i < text.Length; i++)
        {
            var numb = text[i] - '0';
            number = (number * 10) + numb;
        }

        return number;
    }

    private class OrderedList : List<int>
    {
        public new virtual void Add(int item)
        {
            if (Count == 0)
            {
                base.Add(item);
                return;
            }

            for (var i = 0; i < Count; i++)
            {
                if (item > this[i])
                {
                    Insert(i, item);
                    return;
                }
            }

            base.Add(item);
        }
    }

    private class OrderedListWithCounts : OrderedList
    {
        public Dictionary<int, int> countlist = [];

        public override void Add(int item)
        {
            base.Add(item);
            
            if (countlist.ContainsKey(item))
            {
                countlist[item]++;
            }
            else
            {
                countlist.Add(item, 1);
            }
        }

        public int Occurrence(int item)
        {
            if (countlist.TryGetValue(item, out var count))
            {
                return count;
            }

            return 0;
        }
    }
}
