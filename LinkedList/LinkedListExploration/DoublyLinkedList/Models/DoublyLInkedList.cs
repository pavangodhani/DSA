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

        public void Reverse()
        {
            if (Head is null)
                return;

            Node<T>? preceding = null;
            Node<T>? current = Head;
            Node<T>? following;

            while (current != null)
            {
                following = current.Following;
                current.Following = preceding;
                current.Preceding = following;
                preceding = current;
                current = following;
            }

            Head = preceding;
        }

        public void KReverse(int k)
        {
            Head = KReverse(2, Head);
        }

        public bool DetectLoop()
        {
            Node<T>? slow = Head;
            Node<T>? fast = Head;

            while (slow != null && fast != null)
            {
                slow = slow?.Following;
                fast = fast?.Following?.Following;

                if(slow == fast)
                    return true;
            }

            return false;
        }
        #region Private Methods
        private Node<T>? KReverse(int k, Node<T>? head)
        {
            if (head is null)
                return head;

            Node<T>? preceding = null;
            Node<T>? current = head;
            Node<T>? following = null;
            int count = 0;

            while (current != null && count < k)
            {
                following = current.Following;
                current.Following = preceding;
                current.Preceding = following;
                preceding = current;
                current = following;
                count++;
            }

            if (following != null)
                head.Following = KReverse(k, following);

            return preceding;
        }

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
