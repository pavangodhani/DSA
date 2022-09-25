namespace SinglyLinkedList.Models;

public class Node<T>
{
    public T data { get; }

    public Node<T>? Following { get; set; }

    public Node(T data, Node<T>? followingNode = null)
    {
        this.data = data;
        Following = followingNode;
    }
}
