namespace DoublyLinkedList.Models
{
    internal class DoublyLInkedList<T>
    {
        public Node<T>? Head { get; set; }

        public int Count { get; private set; }

        public DoublyLInkedList()
        {
        }

        public void InsertAtHead(T element)
        {
            int position = 0;
            InsertAt(position, element);
        }

        public void InsertAtTail(T element)
        {
            int position = Count;
            InsertAt(position, element);
        }

        public void InsertAt(int position, T element)
        {
            Node<T> newNode = new(element);
            if (Head is null)
                Head = newNode;
            else if (position <= 0)
            {
                Head.Preceding = newNode;
                newNode.Following = Head;
                Head = newNode;
            }
            else
            {
                var precedingNode = NodeAt(position - 1);
                var followingNode = precedingNode?.Following;

                newNode.Preceding = precedingNode;
                newNode.Following = followingNode;

                if (followingNode is not null)
                    followingNode.Preceding = newNode;
                if (precedingNode is not null)
                    precedingNode.Following = newNode;

            }

            Count++;
        }

        public void RemoveAt(int position)
        {
            if (Head is null) return;

            if (position < 0)
                position = 0;
            else if (position >= Count)
                position = Count - 1;

            var node = NodeAt(position);
            var precedingNode = node?.Preceding;
            var followingNode = node?.Following;

            if (precedingNode is null)
                Head = followingNode;
            else
                precedingNode.Following = followingNode;

            if (followingNode is not null)
                followingNode.Preceding = precedingNode;

            Count--;
        }

        public T ElementAt(int position)
        {
            var node = NodeAt(position);
            return node!.Data;
        }
        #region Private Methods
        private Node<T>? NodeAt(int position)
        {
            if (Head is null) return Head;

            if (position <= 0)
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
        #endregion
    }
}
