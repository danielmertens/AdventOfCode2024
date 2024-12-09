namespace AdventOfCode2024.Days;

internal class Day09 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long result = 0;

        var line = GetInputLines()[0];
        var disk = new List<int>();

        for (int i = 0; i < line.Length; i++)
        {
            var amount = line[i] - '0';
            var val = i / 2;
            var free = i % 2 == 1;

            for (int j = 0; j < amount; j++)
            {
                if (free)
                {
                    disk.Add(-1);
                }
                else
                {
                    disk.Add(val);
                }
            }
        }

        // Can't run both parts at the same time currently.
        //Part1(disk);
        Part2(disk);

        // score
        for (int i = 0; i < disk.Count; i++)
        {
            if (disk[i] != -1)
                result += i * disk[i];
        }

        Result(result);
    }

    private static void Part1(List<int> disk)
    {
        var indexLeft = 0;
        var indexRight = disk.Count - 1;

        while (indexLeft < indexRight)
        {
            if (disk[indexLeft] != -1)
            {
                indexLeft++;
                continue;
            }

            if (disk[indexRight] == -1)
            {
                indexRight--;
                continue;
            }

            disk[indexLeft] = disk[indexRight];
            disk[indexRight] = -1;

            indexLeft++;
            indexRight--;
        }
    }

    private static void Part2(List<int> disk)
    {
        var indexLeft = 0;
        var indexRight = disk.Count - 1;
        var alreadyMoved = new HashSet<int>();

        while (indexRight > 0)
        {
            if (disk[indexRight] == -1)
            {
                indexRight--;
                continue;
            }

            if (alreadyMoved.Contains(disk[indexRight]))
            {
                indexRight--;
                continue;
            }

            //count numbers;
            var fragmentCount = 1;
            var val = disk[indexRight];
            while (indexRight - fragmentCount > 0 && disk[indexRight - fragmentCount] == val)
            {
                fragmentCount++;
            }

            // search Space

            indexLeft = 0;
            var freeCount = 0;
            var found = false;
            while (indexLeft < indexRight && !found)
            {
                if (disk[indexLeft] != -1)
                {
                    indexLeft++;
                    continue;
                }

                freeCount = 1;
                while (disk[indexLeft + freeCount] == -1)
                {
                    freeCount++;
                }

                if (freeCount >= fragmentCount)
                {
                    found = true;
                }
                else
                {
                    indexLeft += freeCount + 1;
                }
            }

            if (!found)
            {
                indexRight -= fragmentCount;
                continue;
            }

            for (var i = 0; i < fragmentCount; i++)
            {
                disk[indexLeft] = val;
                disk[indexRight] = -1;

                indexLeft++;
                indexRight--;
            }

            alreadyMoved.Add(val);
        }
    }
}
