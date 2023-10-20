using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualBasic;

namespace Ex6;

public class Program
{
    public static void Main(string[] args)
    {

        //instruction: Give me your birth year...
        var year = GetYear();

        //instruction: Give me your birth month...
        var month = GetMonth();

        //instruction: Give me your birth day...
        var day = GetDay();


        var birthDate = ToDateTime(year, month, day);
        ValidateBirthDate(birthDate);
        Console.WriteLine($"Your birthday is {birthDate.ToShortDateString()}!");
        IsBirthday(birthDate);
        Console.WriteLine();
        var chineseSign = ChineseSign(birthDate.Year);
        Console.WriteLine($"You were born in the year of the {chineseSign}!");
        try
        {
          
        }
        catch (Exception ex)
        {
            Main(null);
        }
    }
    public static int TryAgain(string dateElementType)
    {
        //sort by date element type (if for year, month, day) 
        if (dateElementType == "Year")
        {
            return GetYear();
        }
        if (dateElementType == "Month")
        {
            return GetMonth();
        }
        if (dateElementType == "Day")
        {
            return GetDay();
        }
        return 0;
    }

    private static int GetDay()
    {
        Console.WriteLine("Give me your birth day...");
        var day = Console.ReadLine();
        var dayInt = ToInt(day);

        if (dayInt <= 0 || dayInt >= 32)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            return TryAgain("Day");
        }
        return dayInt;
    }

    private static int GetMonth()
    {
        Console.WriteLine("Give me your birth month...");
        var month = Console.ReadLine();
        var monthInt = ToInt(month);

        if (monthInt <= 0 || monthInt >= 13)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            return TryAgain("Month");
        }
        return monthInt;
    }

    private static int GetYear()
    {
        Console.WriteLine("Give me your birth year...");
        var year = Console.ReadLine();
        var yearInt = ToInt(year);

        if (yearInt <= 1900 || yearInt >= 2023)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            return TryAgain("Year");
        }
        return yearInt;
    }

    public static int ToInt(string datePart)
    {
        var success = int.TryParse(datePart, out var intDatePart);

        if (success)
        {
            return intDatePart;
        }

        return 0;
    }

    public static DateTime ToDateTime(int year, int month, int day)
    {
        try
        {
            var dateTime = new DateTime(year, month, day);

            return dateTime;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Please enter a valid date of birth.");
            Main(null);
        }

        return new DateTime();
    }

    public static void ValidateBirthDate(DateTime date)
    {
        if (date.Year < 1912)
        {
            Console.WriteLine("You are too old asshole! Please enter a valid year");
            Main(null);
        }

        if (date.Year > DateTime.Now.Year)
        {
            Console.WriteLine("You aren't alive asshole! Please enter a valid year");
            Main(null);

        }

    }

    public static void IsBirthday(DateTime date)
    {
        if ((date.Month == DateTime.Now.Month) && (date.Day == DateTime.Now.Day))
        {
            Console.WriteLine("Happy Birthday You Cunt!");
        }
    }



    public static string ChineseSign(int year)
    {
        List<Animal> initialAnimalList = new List<Animal>
        {
            new Animal
            {
                AnimalName = "Rat",
                Year = 1912
            },

            new Animal
            {
                AnimalName = "Ox",
                Year = 1913
            },

            new Animal
            {
                AnimalName = "Tiger",
                Year = 1914
            },

            new Animal
            {
                AnimalName = "Rabbit",
                Year = 1915
            },

            new Animal
            {
                AnimalName = "Dragon",
                Year = 1916
            },

            new Animal
            {
                AnimalName = "Snake",
                Year = 1917
            },

            new Animal
            {
                AnimalName = "Horse",
                Year = 1918
            },

            new Animal
            {
            AnimalName = "Sheep",
            Year = 1919
            },

            new Animal
            {
                AnimalName = "Monkey",
                Year = 1920
            },

            new Animal
            {
                AnimalName = "Monkey",
                Year = 1920
            },

            new Animal
            {
                AnimalName = "Rooster",
                Year = 1921
            },

            new Animal
            {
                AnimalName = "Dog",
                Year = 1922
            },

            new Animal
            {
                AnimalName = "Pig",
                Year = 1923
            }
        };

        var animalList = new List<Animal>();

        foreach (Animal animal in initialAnimalList)
        {
            for (int i = animal.Year; i <= DateTime.Now.Year; i += 12)
            {
                animalList.Add(new Animal
                {
                    AnimalName = animal.AnimalName,
                    Year = i
                });
            }
        }
      
        //use animal list to determ the users chinese horoscope 

        foreach (var animal in animalList)
        {
            if (animal.Year == year)
            {
                return animal.AnimalName;
            }
            
        }

        return "";
    }
}