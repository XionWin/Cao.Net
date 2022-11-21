namespace Domain;
public static class SyntaxExtension
{
    public static T With<T>(this T src, Action<T> action)
    {
        action?.Invoke(src);
        return src;
    }
}

