using System;
using System.Globalization;

namespace SchoolBusCommon.Helpers;

public static class DateUtils
{
    public const string VancouverTimeZone = "America/Vancouver";
    public const string PacificTimeZone = "Pacific Standard Time";

    public static (bool parsed, DateTime? parsedDate) ParseDate(object val)
    {
        if (val == null)
            return (true, null);

        if (val.GetType() == typeof(DateTime))
        {
            return (true, (DateTime)val);
        }

        var formats = new string[] { "yyyyMMdd", "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "yyyyMd", "yyyy-M-d", "yyyy/M/dd", "yyyy.M.d" };
        var dateStr = val.ToString();

        if (string.IsNullOrWhiteSpace(dateStr))
            return (true, null);

        return (DateTime.TryParseExact(dateStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate), parsedDate);
    }

    public static string CovertToString(DateTime date)
    {
        return date.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Returns Pacific time if VancouverTimeZone or PacificTimeZone is defined in the system
    /// Otherwise return UTC time.
    /// </summary>
    /// <param name="utcDate"></param>
    /// <returns></returns>
    public static DateTime ConvertUtcToPacificTime(DateTime utcDate)
    {
        var date = ConvertTimeFromUtc(utcDate, VancouverTimeZone);

        if (date != null)
            return (DateTime)date;

        date = ConvertTimeFromUtc(utcDate, PacificTimeZone);

        if (date != null)
            return (DateTime)date;

        return utcDate;
    }

    private static DateTime? ConvertTimeFromUtc(DateTime date, string timeZoneId)
    {
        try
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(date, timezone);
        }
        catch (TimeZoneNotFoundException)
        {
            return null;
        }
    }

    public static DateTime ConvertPacificToUtcTime(DateTime pstDate)
    {
        var date = ConvertTimeToUtc(pstDate, VancouverTimeZone);

        if (date != null)
            return (DateTime)date;

        date = ConvertTimeToUtc(pstDate, PacificTimeZone);

        if (date != null)
            return (DateTime)date;

        return pstDate;
    }

    private static DateTime? ConvertTimeToUtc(DateTime date, string timeZoneId)
    {
        try
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(date, timezone);
        }
        catch (TimeZoneNotFoundException)
        {
            return null;
        }
    }

    public static (DateTime utcDateFrom, DateTime utcDateTo) GetUtcDateRange(DateTime pstDateFrom, DateTime pstDateTo)
    {
        pstDateFrom = new DateTime(pstDateFrom.Year, pstDateFrom.Month, pstDateFrom.Day, 0, 0, 0);
        pstDateTo = new DateTime(pstDateTo.Year, pstDateTo.Month, pstDateTo.Day, 0, 0, 0)
            .AddDays(1)
            .AddSeconds(-1);

        var utcDateFrom = ConvertPacificToUtcTime(pstDateFrom);
        var utcDateTo = ConvertPacificToUtcTime(pstDateTo);

        return (utcDateFrom, utcDateTo);
    }
}
