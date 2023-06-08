﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualBasic;

namespace Ex6;

public class Program
{
    public static void Main(string[] args)
    {
        //instruction: Give me your birth year...
        Console.WriteLine("Give me your birth year...");
        var year = Console.ReadLine();
        var yearInt = ToInt(year);

        if (yearInt == 0)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            Main(null);
        }

        //instruction: Give me your birth month...
        Console.WriteLine("Give me your birth month...");
        var month = Console.ReadLine();
        var monthInt = ToInt(month);

        if (monthInt == 0)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            Main(null);
        }

        //instruction: Give me your birth day...
        Console.WriteLine("Give me your birth day...");
        var day = Console.ReadLine();
        var dayInt = ToInt(day);

        if (dayInt == 0)
        {
            Console.WriteLine("invalid year. Please re-enter year with a valid int");
            Main(null);
        }

        var birthDate = ToDateTime(yearInt, monthInt, dayInt);
        ValidateBirthDate(birthDate);
        Console.WriteLine($"Your birthday is {birthDate.ToShortDateString()}!");
        IsBirthday(birthDate);
        Console.WriteLine();
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
        if (date.Year < 1900)
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



    public static void ChineseSign(DateTime date)
    {
        
    }
}