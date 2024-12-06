using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

struct Student
{
    public string FullName;  // ФИО
    public int BirthYear;    // Год рождения
    public string Address;   // Домашний адрес
    public string School;    // Оконченная школа

    // Конструктор для инициализации
    public Student(string fullName, int birthYear, string address, string school)
    {
        FullName = fullName;
        BirthYear = birthYear;
        Address = address;
        School = school;
    }

    public override string ToString()
    {
        return $"{FullName}, {BirthYear}, {Address}, {School}";
    }
}

class Program
{
    static void Main()
    {
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr15_2_1\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr15_2_1\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        List<Student> students = File.ReadAllLines(inputFile)
                                        .Select(line =>
                                        {
                                            var parts = line.Split(';');
                                            return new Student(
                                                parts[0],               // ФИО
                                                int.Parse(parts[1]),    // Год рождения
                                                parts[2],               // Адрес
                                                parts[3]                // Школа
                                            );
                                        })
                                        .ToList();

        Console.Write("Введите название школы: ");
        string targetSchool = Console.ReadLine();

        var filteredStudents =
                    from s in students
                    where s.School == targetSchool
                    orderby s.BirthYear
                    select s;

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (var student in filteredStudents)
            {
                writer.WriteLine(student.ToString());
            }
        }

        Console.WriteLine("Информация записана в файл output.txt.");
    }
}

// Школа №1