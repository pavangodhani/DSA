namespace DoublyLinkedList.Models
{
    internal class Node<T>
    {
        public Node<T>? Preceding { get; set; }

        public T Data { get; }

        public Node<T>? Following { get; set; }

        public Node(Node<T>? preceding, T data, Node<T>? following)
        {
            Preceding = preceding;
            Data = data;
            Following = following;
        }

        public Node(Node<T>? preceding, T data)
        {
            Preceding = preceding;
            Data = data;
        }

        public Node(T data, Node<T>? following)
        {
            Data = data;
            Following = following;
        }

        public Node(T data)
        {
            Data = data;
        }
    }
}
