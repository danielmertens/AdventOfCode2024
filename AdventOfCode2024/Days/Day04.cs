namespace AdventOfCode2024.Days;

internal class Day04 : AbstractDay
{
    protected override void Execute()
    {
        UseExample = false;
        long result = 0;

        var lines = GetInputLines();

        var grid = new char[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }

        // HOR
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length - 3; j++)
            {
                if (grid[i][j] == 'X'
                    && grid[i][j + 1] == 'M'
                    && grid[i][j + 2] == 'A'
                    && grid[i][j + 3] == 'S')
                {
                    result++;
                    continue;
                }

                if (grid[i][j] == 'S'
                    && grid[i][j + 1] == 'A'
                    && grid[i][j + 2] == 'M'
                    && grid[i][j + 3] == 'X')
                {
                    result++;
                    continue;
                }
            }
        }

        //VERT
        for (int i = 0; i < grid[0].Length; i++)
        {
            for (int j = 0; j < grid.Length - 3; j++)
            {
                if (grid[j][i] == 'X'
                    && grid[j + 1][i] == 'M'
                    && grid[j + 2][i] == 'A'
                    && grid[j + 3][i] == 'S')
                {
                    result++;
                    continue;
                }

                if (grid[j][i] == 'S'
                    && grid[j + 1][i] == 'A'
                    && grid[j + 2][i] == 'M'
                    && grid[j + 3][i] == 'X')
                {
                    result++;
                    continue;
                }
            }
        }

        // DIAG Right
        for (int i = 0; i < grid.Length - 3; i++)
        {
            for (int j = 0; j < grid[i].Length - 3; j++)
            {
                if (grid[i][j] == 'X'
                    && grid[i + 1][j + 1] == 'M'
                    && grid[i + 2][j + 2] == 'A'
                    && grid[i + 3][j + 3] == 'S')
                {
                    result++;
                    continue;
                }

                if (grid[i][j] == 'S'
                    && grid[i + 1][j + 1] == 'A'
                    && grid[i + 2][j + 2] == 'M'
                    && grid[i + 3][j + 3] == 'X')
                {
                    result++;
                    continue;
                }
            }
        }

        // DIAG Left
        for (int i = 0; i < grid.Length - 3; i++)
        {
            for (int j = 0; j < grid[i].Length - 3; j++)
            {
                if (grid[i + 3][j] == 'X'
                    && grid[i + 2][j + 1] == 'M'
                    && grid[i + 1][j + 2] == 'A'
                    && grid[i][j + 3] == 'S')
                {
                    result++;
                    continue;
                }

                if (grid[i + 3][j] == 'S'
                    && grid[i + 2][j + 1] == 'A'
                    && grid[i + 1][j + 2] == 'M'
                    && grid[i][j + 3] == 'X')
                {
                    result++;
                    continue;
                }
            }
        }



        var p2 = 0;

        for (int i = 1; i < grid.Length - 1; i++)
        {
            for (int j = 1; j < grid[i].Length - 1; j++)
            {
                if (grid[i][j] != 'A') continue;

                if ((grid[i - 1][j - 1] == 'M' && grid[i + 1][j + 1] == 'S' 
                    || grid[i - 1][j - 1] == 'S' && grid[i + 1][j + 1] == 'M')
                    &&
                    (grid[i - 1][j + 1] == 'M' && grid[i + 1][j - 1] == 'S'
                    || grid[i - 1][j + 1] == 'S' && grid[i + 1][j - 1] == 'M')
                    )
                {
                    p2++;

                }
            }
        }

        Result(result);
        Result(p2);
    }
}
