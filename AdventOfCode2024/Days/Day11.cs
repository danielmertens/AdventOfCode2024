namespace AdventOfCode2024.Days;

internal class Day11 : AbstractDay
{
    protected override void Execute()
    {   
        var line = GetInputLines()[0];
        var numbers = line.Split(' ').Select(long.Parse).ToArray();

        var memory = new Dictionary<long, NumberNode>();

        foreach (var number in numbers)
        {
            NumberNode node;
            if (!memory.TryGetValue(number, out node))
            {
                node = new NumberNode()
                {
                    Value = number,
                    OccurencesOnBlink = new long[76]
                };
                node.OccurencesOnBlink[0] = 1;
                memory.Add(number, node);
            }
            else
            {
                node.OccurencesOnBlink[0]++;
            }
        }

        var blinkGoal = 75;
        for (int i = 0; i < blinkGoal; i++)
        {
            var memoryValues = memory.Select(m => m.Value).ToArray();
            foreach (var value in memoryValues)
            {
                value.Blink(i, memory);
            }
        }

        Result(memory.Select(m => m.Value).Sum(v => v.OccurencesOnBlink[25]));
        Result(memory.Select(m => m.Value).Sum(v => v.OccurencesOnBlink[blinkGoal]));
    }

    private class NumberNode
    {
        public long Value { get; set; }
        public long[] OccurencesOnBlink { get; set; }
        public NumberNode[] Next { get; set; }

        public void Blink(int blinkIndex, Dictionary<long, NumberNode> memory)
        {
            if (OccurencesOnBlink[blinkIndex] == 0) return;

            if (Next == null)
            {
                if (Value == 0)
                {
                    if (memory.TryGetValue(1, out NumberNode? foundNode))
                    {
                        Next = [foundNode];
                    }
                    else
                    {
                        var newNode = new NumberNode { Value = 1, OccurencesOnBlink = new long[OccurencesOnBlink.Length] };
                        Next = [newNode];
                        memory.Add(1, newNode);
                    }
                }
                else if (HasEvenDigits(Value))
                {
                    var txt = Value.ToString();
                    var half = txt.Length / 2;
                    var firstHalf = txt.Substring(0, half);
                    var secondHalf = txt.Substring(half);

                    var firstNumber = long.Parse(firstHalf);
                    var secondNumber = long.Parse(secondHalf);

                    NumberNode node1;
                    NumberNode node2;
                    if (!memory.TryGetValue(firstNumber, out node1))
                    {
                        node1 = new NumberNode { Value = firstNumber, OccurencesOnBlink = new long[OccurencesOnBlink.Length] };
                        memory.Add(firstNumber, node1);
                    }
                    if (!memory.TryGetValue(secondNumber, out node2))
                    {
                        node2 = new NumberNode { Value = secondNumber, OccurencesOnBlink = new long[OccurencesOnBlink.Length] };
                        memory.Add(secondNumber, node2);
                    }

                    Next = [ node1, node2 ];
                }
                else
                {
                    var nextValue = Value * 2024;
                    if (memory.TryGetValue(nextValue, out NumberNode? foundNode))
                    {
                        Next = [foundNode];
                    }
                    else
                    {
                        var newNode = new NumberNode { Value = Value * 2024, OccurencesOnBlink = new long[OccurencesOnBlink.Length] };
                        Next = [newNode];
                        memory.Add(nextValue, newNode);
                    }
                }
            }

            foreach (var node in Next)
            {
                node.OccurencesOnBlink[blinkIndex + 1] += OccurencesOnBlink[blinkIndex];
            }
        }

        private static bool HasEvenDigits(long value)
        {
            var txt = value.ToString();
            return txt.Length % 2 == 0;
        }
    }
}
