namespace SinglyLinkedList.Models;

public class Node<T>
{
    public T Data { get; }

    public Node<T>? Following { get; set; }

    public Node(T data, Node<T>? followingNode = null)
    {
        Data = data;
        Following = followingNode;
    }

    ~Node()
    {
        Console.WriteLine($"Memory is free for node with data -> {Data}");    
    }
}
