using System;
using System.IO;

public class Node<T>
{
    public T Inf;
    public Node<T> Next;
    public Node(T nodeInfo)
    {
        Inf = nodeInfo;
        Next = null;
    }
}

public class My_List<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public My_List()
    {
        head = null;
        tail = null;
    }

    public void AddEnd(T nodeInfo)
    {
        Node<T> r = new Node<T>(nodeInfo);
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
        Node<T> r = head;
        while (r != null)
        {
            Console.Write("{0} ", r.Inf);
            r = r.Next;
        }
        Console.WriteLine();
    }

    public void ReadFromFile(string filename, Func<string, T> parser)
    {
        string[] values = File.ReadAllText(filename).Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string val in values)
        {
            try
            {
                AddEnd(parser(val));
            }
            catch
            {
                Console.WriteLine($"Ошибка при чтении значения: {val}");
            }
        }
    }

    public void WriteToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            Node<T> r = head;
            while (r != null)
            {
                writer.Write(r.Inf + " ");
                r = r.Next;
            }
        }
    }

    public void DeleteBefore(T x)
    {
        if (head == null || head.Next == null) return;

        Node<T> prev = null;
        Node<T> current = head;

        while (current != null && current.Next != null)
        {
            if (current.Next.Inf.CompareTo(x) == 0)
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
        My_List<int> myList = new My_List<int>();

        myList.ReadFromFile("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr20_6\\input.txt", int.Parse);

        Console.WriteLine("Исходный список:");
        myList.Show();
        
        Console.Write("Введите x: ");
        int x = int.Parse(Console.ReadLine());
        myList.DeleteBefore(x);

        Console.WriteLine("Обработанный список:");
        myList.Show();

        myList.WriteToFile("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr20_6\\output.txt");
    }
}
