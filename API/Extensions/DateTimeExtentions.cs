using System;

namespace API.Extensions;

public static class DateTimeExtentions
{
      public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - dob.Year;

        //birthday in current year.
        DateOnly birthdayThisYear;
        if (dob.Month == 2 && dob.Day == 29 && !DateTime.IsLeapYear(today.Year))
        {
            // In non‑leap years, consider Feb 28 as the birthday.
            birthdayThisYear = new DateOnly(today.Year, 2, 28);
        }
        else
        {
            birthdayThisYear = new DateOnly(today.Year, dob.Month, dob.Day);
        }

        // If today's date is before the birthday, subtract one from age.
        if (today < birthdayThisYear)
        {
            age--;
        }

        return age;
    }

    // Course way of doing it bothers me
    // public static int CalculateAge(this DateOnly dob){
    //     var today = DateOnly.FromDateTime(DateTime.Now);
    //     var age = today.Year - dob.Year;

    //     if(dob > today.AddYears(-age)) age--;

    //     return age;
    // }
}
