using System.Diagnostics;
using TextCopy;

namespace AdventOfCode2024.Days;

internal abstract partial class AbstractDay
{
    private readonly Clipboard _clipboard = new();
    protected Stopwatch _stopWatch;

    public void SolveProblem()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintHeader();

        _stopWatch = Stopwatch.StartNew();
        Execute();
        _stopWatch.Stop();

        PrintFooter(_stopWatch);
        Console.ForegroundColor = ConsoleColor.White;
    }


    private void PrintHeader()
    {
        var headerText = $"||  RUNNING {GetType().Name.ToUpper()}  ||";

        Console.WriteLine(new string('=', headerText.Length));
        Console.WriteLine(headerText);
        Console.WriteLine(new string('=', headerText.Length));
    }

    private void PrintFooter(Stopwatch stopWatch)
    {
        var footerText = string.Format("Execution time {0}", stopWatch.Elapsed);
        Console.WriteLine(new string('-', footerText.Length));
        Console.WriteLine(footerText);
    }

    protected void Result<T>(T result)
    {
        var resultText = result.ToString();
        Console.WriteLine("Result: " + resultText);
        _clipboard.SetText(resultText);
    }

    protected void Result<T>(T result, int part)
    {
        var resultText = result.ToString();
        Console.WriteLine($"PART {part}: {resultText}");
    }

    protected abstract void Execute();
}
