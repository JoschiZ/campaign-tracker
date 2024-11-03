using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core;

public interface ILogEntry : ICreationTracking
{
    public string Reason { get; }
}

public interface ILogEntry<out TProperty> : ILogEntry
{
    public TProperty NewValue { get; }
}

public interface IDeltaLogEntry : ILogEntry
{
    public int Delta { get; }
}