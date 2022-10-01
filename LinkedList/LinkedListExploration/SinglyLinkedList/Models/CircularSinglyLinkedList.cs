namespace SinglyLinkedList.Models
{
    public class CircularSinglyLinkedList<T>
    {
        public Node<T>? Head { get; private set; }

        public int Count { get; set; }

        public void InsertAt(int position, T element)
        {
            Node<T> newNode = new(element);
            if (Head is null)
            {
                Head = newNode;
                Head.Following = Head;
            }
            else if (position < 0)
            {
                newNode.Following = Head;
                Head = newNode;
            }
            else
            {
                var precedingNode = NodeAt(position - 1);
                newNode.Following = precedingNode?.Following;
                if (precedingNode is not null)
                    precedingNode.Following = newNode;

            }
            Count++;
        }

        private Node<T>? NodeAt(int position)
        {
            if (Head is null)
                return null;

            if (position < 0)
                position = 0;
            else if (position >= Count)
                position = Count - 1;

            var node = Head;
            for (int i = 1; i <= position; i++)
            {
                node = node?.Following;
            }
            return node;
        }
    }
}
