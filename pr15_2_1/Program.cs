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

    // Метод для красивого вывода информации о студенте
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

        // Чтение данных из файла и создание списка студентов
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

        // Запрос у пользователя названия школы
        Console.Write("Введите название школы: ");
        string targetSchool = Console.ReadLine();

        // Фильтрация и сортировка студентов по году рождения
        var filteredStudents = students.Where(s => s.School == targetSchool)
                                        .OrderBy(s => s.BirthYear)
                                        .ToList();

        File.WriteAllLines(outputFile, filteredStudents.Select(s => s.ToString()));

        Console.WriteLine("Информация записана в файл output.txt.");
    }
}

// Школа №1