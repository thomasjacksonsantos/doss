namespace System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static void ForEach<T>(
    this IEnumerable<T> source,
    Action<T> action)
    {
        foreach (T element in source)
            action(element);
    }

    public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
    {
        foreach (var cur in e)
        {
            yield return cur;
        }
        yield return value;
    }
}