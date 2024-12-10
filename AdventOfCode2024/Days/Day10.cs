
namespace AdventOfCode2024.Days;

internal class Day10 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long result = 0;
        long ratings = 0;

        var lines = GetInputLines();

        var map = new int[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            map[i] = lines[i].ToCharArray().Select(c => c - '0').ToArray();
        }

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 0)
                {
                    var (score, rating) = CalculateScoreAndRating(map, x, y);
                    result += score;
                    ratings += rating;
                }
            }
        }

        Result(result);
        Result(ratings);
    }

    private (int score, int rating) CalculateScoreAndRating(int[][] map, int startX, int startY)
    {
        var queue = new Queue<(int x, int y)[]>();
        queue.Enqueue([(startX, startY)]);

        var visited = new HashSet<(int, int)>();

        var rating = 0;
        var score = 0;
        while (queue.Count > 0)
        {
            var next = queue.Dequeue();

            var (x, y) = next[next.Length - 1];

            var height = map[y][x];

            if (height == 9)
            {
                rating++;
                if (!visited.Contains((x, y)))
                {
                    visited.Add((x, y));
                    score++;
                }
                continue;
            }

            if (x > 0 && map[y][x - 1] == height + 1)
            {
                queue.Enqueue([..next, (x - 1, y)]);
            }
            if (x < map[y].Length - 1 && map[y][x + 1] == height + 1)
            {
                queue.Enqueue([.. next, (x + 1, y)]);
            }

            if (y > 0 && map[y - 1][x] == height + 1)
            {
                queue.Enqueue([.. next, (x, y - 1)]);
            }
            if (y < map.Length - 1 && map[y + 1][x] == height + 1)
            {
                queue.Enqueue([.. next, (x, y + 1)]);
            }
        }

        return (score, rating);
    }
}
