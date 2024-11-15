using System;
using System.IO;
using System.Linq;

struct Student : IComparable<Student>
{
    public string FullName;       // ФИО студента
    public int BirthYear;         // Год рождения
    public string Address;        // Домашний адрес
    public string School;         // Оконченная школа

    public Student(string fullName, int birthYear, string address, string school)
    {
        FullName = fullName;
        BirthYear = birthYear;
        Address = address;
        School = school;
    }

    public int CompareTo(Student other)
    {
        return BirthYear.CompareTo(other.BirthYear);
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
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr14_2_1\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr14_2_1\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        Student[] students = new Student[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            students[i] = new Student(
                parts[0],
                int.Parse(parts[1]),
                parts[2],
                parts[3]
            );
        }

        Console.Write("Введите название школы: ");
        string targetSchool = Console.ReadLine();
        var filteredStudents = students
            .Where(student => student.School == targetSchool)
            .ToArray();

        Array.Sort(filteredStudents);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (var student in filteredStudents)
            {
                writer.WriteLine(student);
            }
        }

        Console.WriteLine("Информация записана в файл output.txt");
    }
}

//Школа №1