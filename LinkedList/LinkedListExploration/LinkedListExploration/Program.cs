// See https://aka.ms/new-console-template for more information

#region Singly Linked List
using SinglyLinkedList.Models;

SinglyLinkedList<int> singlyLinkedList = new();

Random random = new Random();

int n = 10;
while (n != 0)
{
    singlyLinkedList.Insert(n);
    n--;
}

//singlyLinkedList.Head.Following.Following.Following = singlyLinkedList.Head;

Console.WriteLine($"Loop detected: {singlyLinkedList.DetectLoop()}");

//singlyLinkedList.Remove();
//singlyLinkedList.Remove();
//singlyLinkedList.RemoveAt(5);
//singlyLinkedList.RemoveFromBeginning();
//singlyLinkedList.RemoveFromBeginning();

//for (int i = 0; i < singlyLinkedList.Count; i++)
//{
//    Console.WriteLine($"Position {i + 1} : {singlyLinkedList.ElementAt(i)}");
//}

//Console.WriteLine($"\nTotal count: {singlyLinkedList.Count}\n");

//Console.WriteLine($"Element present: {singlyLinkedList.Contains(7)}");
#endregion