// See https://aka.ms/new-console-template for more information
using DoublyLinkedList.Models;

Console.WriteLine("Hello, World!");


DoublyLInkedList<int> doublyLinkedList = new DoublyLInkedList<int>();

int n = 5;
while (n != 0)
{
    doublyLinkedList.InsertAtTail(n);
    n--;
}

for (int i = 0; i < doublyLinkedList.Count; i++)
{
    Console.WriteLine($"Index {i} : {doublyLinkedList.ElementAt(i)}");
}

Console.WriteLine($"\nTotal count: {doublyLinkedList.Count}\n");


doublyLinkedList.InsertAt(0, 101010);
PrintLinkedList("InsertAt");
doublyLinkedList.InsertAt(2, 101010);
PrintLinkedList("InsertAt");
doublyLinkedList.InsertAt(50, 101010);
PrintLinkedList("InsertAt");

void PrintLinkedList(string? operation = null)
{
    string message = operation ?? "After performing some operations";
    Console.WriteLine($"***********************{message}************************");
    for (int i = 0; i < doublyLinkedList.Count; i++)
    {
        Console.WriteLine($"Index {i} : {doublyLinkedList.ElementAt(i)}");
    }
    Console.WriteLine($"\nTotal count: {doublyLinkedList.Count}\n");
}