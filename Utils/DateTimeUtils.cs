namespace AutoRapido.Utils;

public class DateTimeUtils
{
    private static readonly Random Random = new Random();

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
        int month = Random.Next(1, 13); // Generate random month and day to counter the lack of precision in the csv 
        int day = Random.Next(1, 28);

            return new DateTime(yearInt, month, day, 0, 0, 0, DateTimeKind.Utc);
    }
    
    public static DateTime RandomDateTime()
    {    
        int yearInt = Random.Next(1940, 2025);
        int month = Random.Next(1, 13);
        int day = Random.Next(1, 28);

        return new DateTime(yearInt, month, day, 0, 0, 0, DateTimeKind.Utc);
    }

}