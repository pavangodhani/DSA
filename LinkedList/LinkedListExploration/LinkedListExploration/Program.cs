// See https://aka.ms/new-console-template for more information

#region Singly Linked List
using SinglyLinkedList.Models;

SinglyLinkedList<int> singlyLinkedList = new();
CircularSinglyLinkedList<int> circularSinglyLinkedList = new();

int n = 4;
while (n != 0)
{
    singlyLinkedList.InsertAtTail(n);
    n--;
}

for (int i = 0; i < singlyLinkedList.Count; i++)
{
    Console.WriteLine($"Index {i} : {singlyLinkedList.ElementAt(i)}");
}

Console.WriteLine($"\nTotal count: {singlyLinkedList.Count}\n");



//singlyLinkedList.InsertAtHead(11);
//PrintLinkedList("InsertAtHead");
//singlyLinkedList.InsertAtMiddle(1010101010);
//PrintLinkedList("InsertAtMiddle");
//singlyLinkedList.InsertAtTail(0);
//PrintLinkedList("InsertAtTail");
//singlyLinkedList.InsertAt(1, 11111);
//PrintLinkedList("InsertAt");

//singlyLinkedList.InsertAt(0, 11111);
//singlyLinkedList.InsertAt(7, 11111);
//singlyLinkedList.InsertAt(12, 11111);
//singlyLinkedList.InsertAt(100, 11111);

//singlyLinkedList.Remove();
//singlyLinkedList.Remove();
//singlyLinkedList.RemoveAt(1);
//PrintLinkedList("RemoveAt");
//singlyLinkedList.RemoveFromBeginning();
//singlyLinkedList.RemoveFromBeginning();

singlyLinkedList.Reverse();
PrintLinkedList("Reverse");
//singlyLinkedList.ReverseRec();
//PrintLinkedList("ReverseRec");
singlyLinkedList.ReverseInGroup(2);
PrintLinkedList("ReverseInGroup");

Console.WriteLine($"\n\n Middle: {singlyLinkedList.Middle()}");


//Console.WriteLine($"Element present: {singlyLinkedList.Contains(7)}");
#endregion

#region Detect Loop
//singlyLinkedList.Head.Following.Following.Following = singlyLinkedList.Head;
//singlyLinkedList.Head.Following = singlyLinkedList.Head;

//Console.WriteLine($"Loop detected: {singlyLinkedList.DetectLoop()}");

#endregion

void PrintLinkedList(string? operation = null)
{
    string message = operation ?? "After performing some operations";
    Console.WriteLine($"***********************{message}************************");
    for (int i = 0; i < singlyLinkedList.Count; i++)
    {
        Console.WriteLine($"Index {i} : {singlyLinkedList.ElementAt(i)}");
    }
    Console.WriteLine($"\nTotal count: {singlyLinkedList.Count}\n");
}
