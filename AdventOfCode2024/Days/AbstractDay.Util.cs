using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days;

internal abstract partial class AbstractDay
{
    public bool UseExample { get; set; } = false;

    private string GetFolder()
    {
        return UseExample ? "Examples" : "Inputs";
    }

    private static T ConvertValue<T>(string value)
    {
        return (T)Convert.ChangeType(value, typeof(T));
    }

    protected string GetInput() => File.ReadAllText($"./{GetFolder()}/{GetType().Name}.txt");

    protected string GetInput(string file) => File.ReadAllText($"./{GetFolder()}/{file}");

    protected string[] GetInputLines() => File.ReadAllLines($"./{GetFolder()}/{GetType().Name}.txt");

    protected string[] GetInputLines(string file) => File.ReadAllLines($"./{GetFolder()}/{file}");

    protected string[][] GetInputLinesSplit(string delimiter = " ")
        => GetInputLines().Select(line => line.Split(delimiter)).ToArray();

    protected string[][] GetInputLinesSplit(string file, string delimiter = " ")
        => GetInputLines(file).Select(line => line.Split(delimiter)).ToArray();

    protected (T1, T2)[] GetInputLinesSplit<T1, T2>(string delimiter = " ")
        => GetInputLinesSplit(delimiter)
            .Select(l => (ConvertValue<T1>(l[0]), ConvertValue<T2>(l[1])))
            .ToArray();

    protected (T1, T2, T3)[] GetInputLinesSplit<T1, T2, T3>(string delimiter = " ")
        => GetInputLinesSplit(delimiter)
            .Select(l => (ConvertValue<T1>(l[0]), ConvertValue<T2>(l[1]), ConvertValue<T3>(l[2])))
            .ToArray();

    protected (T1, T2, T3, T4)[] GetInputLinesSplit<T1, T2, T3, T4>(string delimiter = " ")
        => GetInputLinesSplit(delimiter)
            .Select(l => (ConvertValue<T1>(l[0]), ConvertValue<T2>(l[1]), ConvertValue<T3>(l[2]), ConvertValue<T4>(l[3])))
            .ToArray();

    protected (T1, T2, T3, T4, T5)[] GetInputLinesSplit<T1, T2, T3, T4, T5>(string delimiter = " ")
        => GetInputLinesSplit(delimiter)
            .Select(l => (ConvertValue<T1>(l[0]), ConvertValue<T2>(l[1]), ConvertValue<T3>(l[2]), ConvertValue<T4>(l[3]), ConvertValue<T5>(l[4])))
            .ToArray();

    protected int[] GetInputNumbers() => GetInputLines().Select(int.Parse).ToArray();

    protected int[] GetInputNumbers(string file) => GetInputLines(file).Select(l => int.Parse(l)).ToArray();

    protected bool[] ESieve(int max)
    {
        var arr = Enumerable.Repeat(true, max + 1).ToArray();
        var limit = Math.Sqrt(max);

        for (int i = 2; i <= limit; i++)
        {
            if (arr[i])
            {
                for (int j = i * i; j <= max; j += i)
                {
                    arr[j] = false;
                }
            }
        }

        return arr;
    }
}
