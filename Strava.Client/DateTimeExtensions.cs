namespace Strava.Client;

public static class DateTimeExtensions
{
    public static long ToUnixTimeSeconds(this DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
}