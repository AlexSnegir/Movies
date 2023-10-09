namespace Movies.Persistence.Infrastructure;

public sealed class ConnectionString
{
    public const string SettingsKey = "MoviesDB";

    public ConnectionString(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;
}