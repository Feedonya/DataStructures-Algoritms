using System;
using System.IO;


public class Node
{
    public object Inf;
    public Node Next;
    public Node(object nodeInfo)
    {
        Inf = nodeInfo;
        Next = null;
    }
}

public class List
{
    private Node head;
    private Node tail;

    public List()
    {
        head = null;
        tail = null;
    }

    public void AddEnd(object nodeInfo)
    {
        Node r = new Node(nodeInfo);
        if (head == null)
        {
            head = r;
            tail = r;
        }
        else
        {
            tail.Next = r;
            tail = r;
        }
    }

    public void Show()
    {
        Node r = head;
        while (r != null)
        {
            Console.Write("{0} ", r.Inf);
            r = r.Next;
        }
        Console.WriteLine();
    }

    public void ReadFromFile(string filename)
    {
        string[] numbers = File.ReadAllText(filename).Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string num in numbers)
        {
            if (int.TryParse(num, out int value))
            {
                AddEnd(value);
            }
        }
    }

    public void WriteToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            Node r = head;
            while (r != null)
            {
                writer.Write(r.Inf + " ");
                r = r.Next;
            }
        }
    }

    public void DeleteBefore(object x)
    {
        if (head == null || head.Next == null) return;

        Node prev = null;
        Node current = head;
        Node beforeCurrent = null;

        while (current != null && current.Next != null)
        {
            if (((IComparable)(current.Next.Inf)).CompareTo(x) == 0)
            {
                if (prev != null)
                {
                    prev.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                current = current.Next;
            }
            else
            {
                prev = current;
                current = current.Next;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        List myList = new List();

        myList.ReadFromFile("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr20_6\\input.txt");

        Console.WriteLine("Исходный список:");
        myList.Show();

        Console.Write("Введите x: ");
        int x = int.Parse(Console.ReadLine());
        myList.DeleteBefore(x);

        Console.WriteLine("Обработанный список:");
        myList.Show();

        myList.WriteToFile("output.txt");
    }
}
