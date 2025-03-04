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
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_2_2\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_2_2\\output.txt";

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

        var groupedBySchool = students.GroupBy(s => s.School);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (var group in groupedBySchool)
            {
                writer.WriteLine($"Школа: {group.Key}");
                foreach (var student in group)
                {
                    writer.WriteLine(student.ToString());
                }
                writer.WriteLine();
            }
        }
        Console.WriteLine("Информация сгруппирована по школам и записана в файл output.txt.");
    }
}