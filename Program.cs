using System.ComponentModel;
using ModelContextProtocol.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMcpServer()
    .WithHttpTransport()
    .WithTools<NumberTools>();

var app = builder.Build();

app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
app.MapMcp("/mcp");

app.Run();

[McpServerToolType]
public sealed class NumberTools
{
    [McpServerTool, Description("计算一组数字的最大值、最小值、数量、总和与平均值。")] 
    public NumberStatistics CalculateStatistics(
        [Description("要统计的数字列表，例如 [1.5, 2, -3, 4.5]。")] IReadOnlyList<double> numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);

        if (numbers.Count == 0)
        {
            throw new ArgumentException("numbers 至少需要包含一个数字。", nameof(numbers));
        }

        if (numbers.Any(double.IsNaN) || numbers.Any(double.IsInfinity))
        {
            throw new ArgumentException("numbers 不能包含 NaN 或无穷大。", nameof(numbers));
        }

        var sum = numbers.Sum();
        return new NumberStatistics(
            Maximum: numbers.Max(),
            Minimum: numbers.Min(),
            Count: numbers.Count,
            Sum: sum,
            Average: sum / numbers.Count);
    }
}

public sealed record NumberStatistics(
    double Maximum,
    double Minimum,
    int Count,
    double Sum,
    double Average);

