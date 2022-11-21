namespace Domain;
public class Result
{
    public static Result OK() => new Result();
}

public static class ResultExtension
{
    public static Result<T> OK<T>(this T src) => new Result<T>(){ Value = src };
}

public class Result<T>
{
    public required T Value { get; init; }
}
