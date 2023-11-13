namespace Doss.Core.Seedwork;

public static class ObjectExtensions
{
    public static bool IsNull<T>(this T? value)
        => value is not { };

    public static bool IsNotNull<T>(this T? value)
        => value is { };
}