namespace AutoRapido.Utils;

public class DateTimeUtils
{
    private static readonly Random random = new Random();

    public static DateTime ConvertToDateTime(String dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime birthdate))
        {
            if (birthdate.Day == 0 && birthdate.Month == 0)
            {
                return ConvertYearToDateTime(birthdate.Year);
            }
            return birthdate.ToUniversalTime();

        }

        Console.WriteLine($"BirthDate Invalide");
        return DateTime.UtcNow;
    }

    public static DateTime ConvertYearToDateTime(int yearInt)
    {    
        int month = random.Next(1, 13);
        int day = random.Next(1, 28);

            return new DateTime(yearInt, month, day, 0, 0, 0, DateTimeKind.Utc);
    }
    
    public static DateTime RandomDateTime(int yearInt = 200000)
    {    
        if (yearInt == 200000) {
            yearInt = random.Next(1940, 2025);
        }
        int month = random.Next(1, 13);
        int day = random.Next(1, 28);

        return new DateTime(yearInt, month, day, 0, 0, 0, DateTimeKind.Utc);
    }

}