namespace SinglyLinkedList.Models
{
    public class SinglyLinkedList<T>
    {
        public Node<T>? Head;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
        }

        #region Public Methods
        public void InsertAtHead(T element)
        {
            int position = 0;
            InsertAt(position, element);
        }

        public void InsertAtMiddle(T element)
        {
            int position = (Count - 1) / 2;
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
            var precedingNode = NodeAt(position - 1);

            if (Head is null || precedingNode is null)
                Head = newNode;
            else if (position <= 0)
            {
                newNode.Following = Head;
                Head = newNode;
            }
            else
            {
                newNode.Following = precedingNode.Following;
                precedingNode.Following = newNode;
            }

            Count++;
        }

        public void RemoveAtHead()
        {
            if (Head is null)
                return;

            Head = Head.Following;
            Count--;
        }

        public void RemoveAtTail()
        {
            if (Head is null)
                return;

            Node<T> last = Head;
            Node<T>? preceding = null;

            while (last.Following != null)
            {
                preceding = last;
                last = last.Following;
            }

            if (preceding is null)
                Head = null;
            else
                preceding.Following = null;

            Count--;
        }

        public void RemoveAt(int position)
        {
            if (Head is null)
                return;

            if (position <= 0)
                Head = Head.Following;
            else
            {
                Node<T> preceding = Head;
                Node<T> element = Head;

                for (int i = 1; i <= position; i++)
                {
                    preceding = element;
                    element = element.Following!;
                }

                preceding.Following = element.Following;
            }
            Count--;
        }

        public T ElementAt(int position)
        {
            if (position > Count - 1 || position < 0)
                throw new IndexOutOfRangeException();

            if (Head is null)
                throw new Exception();

            Node<T> element = Head;
            for (int i = 1; i <= position; i++)
            {
                element = element.Following!;
            }

            return element.Data;
        }

        public bool Contains(T element)
        {
            return ContainsRec(Head, element);
        }

        public long Size()
        {
            return SizeRec(Head);
        }

        public bool DetectLoop()
        {
            //return DetectLoopUsingHashSet();
            return DetectLoopUsingFloydCycleFindingAlgo();
        }

        public void Reverse()
        {
            if (Head is null || Head?.Following is null)
                return;

            Node<T>? precedingNode = null;
            Node<T>? current = Head;
            Node<T>? followingNode;

            while (current != null)
            {
                followingNode = current.Following;
                current.Following = precedingNode;
                precedingNode = current;
                current = followingNode;
            }

            Head = precedingNode;
        }

        public void ReverseRec()
        {
            ReverseRec(null, Head, null);
        }

        public T? Middle()
        {
            if (Head is null)
                return default;

            if (Head.Following is null)
                return Head.Data;

            var slowNode = Head;
            var fastNode = Head.Following;

            while (fastNode != null)
            {
                slowNode = slowNode?.Following;
                fastNode = slowNode?.Following?.Following;
            }
            return slowNode.Data;
        }

        public void ReverseInGroup(int groupCount)
        {
            
        }
        #endregion

        #region Private Methods
        private void ReverseRec(Node<T>? preceding, Node<T>? current, Node<T>? following)
        {
            if (current is null)
            {
                Head = preceding;
                return;
            }

            following = current.Following;
            current.Following = preceding;
            preceding = current;
            current = following;

            ReverseRec(preceding, current, following);
        }

        private Node<T>? NodeAt(int position)
        {
            if (Head is null) return Head;

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

        private long SizeRec(Node<T>? element)
        {
            if (element is null)
                return 0;

            return 1 + SizeRec(Head?.Following);
        }

        private bool ContainsRec(Node<T>? element, T elementToFind)
        {
            if (element is null)
                return false;

            if (element.Data!.Equals(elementToFind))
                return true;

            return ContainsRec(element.Following, elementToFind);
        }

        private bool DetectLoopUsingHashSet()
        {
            if (Head is null)
                return false;

            HashSet<Node<T>> uniqueNodes = new HashSet<Node<T>>();
            var node = Head;

            while (node.Following != null)
            {
                if (uniqueNodes.Contains(node))
                    return true;

                uniqueNodes.Add(node);
                node = node.Following;
            }

            return false;
        }

        private bool DetectLoopUsingFloydCycleFindingAlgo()
        {
            if (Head is null)
                return false;

            var node_slow = Head;
            var node_fast = Head;

            while (node_slow != null &&
                   node_fast != null &&
                   node_fast.Following != null)
            {
                node_slow = node_slow.Following;
                node_fast = node_fast.Following.Following;

                if (node_fast == node_slow)
                    return true;
            }

            return false;
        }
        #endregion
    }
}
