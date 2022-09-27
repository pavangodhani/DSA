using System.Xml.Linq;

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
            Node<T> newNode = new(element);

            if (Head is null)
                Head = newNode;
            else
            {
                newNode.Following = Head;
                Head = newNode;
            }

            Count++;
        }

        public void InsertAtMiddle(T element)
        {
            int position = (Count - 1) / 2;
            InsertAt(position, element);
        }

        public void InsertAtTail(T element)
        {
            Node<T> newNode = new(element);

            if (Head is null)
                Head = newNode;
            else
            {
                Node<T> last = Head;

                while (last.Following != null)
                    last = last.Following;

                last.Following = newNode;
            }

            Count++;
        }

        public void InsertAt(int position, T element)
        {
            if (position <= 0)
            {
                InsertAtHead(element);
                return;
            }

            if (position >= Count)
            {
                InsertAtTail(element);
                return;
            }

            Node<T> newNode = new(element);
            
            if (Head is null)
                Head = newNode;
            else
            {
                var precedingNode = NodeAt(position - 1);
                if (precedingNode is null) return;

                newNode.Following = precedingNode.Following;
                precedingNode.Following = newNode;
            }

            Count++;
        }


        public void RemoveFromBeginning()
        {
            if (Head is null)
                return;

            Head = Head.Following;
            Count--;
        }

        public void Remove()
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
            if (position > Count - 1 || position < 0)
                throw new IndexOutOfRangeException();

            if (Head is null)
                return;

            Node<T> preceding = Head;
            Node<T> element = Head;

            for (int i = 1; i <= position; i++)
            {
                preceding = element;
                element = element.Following!;
            }

            preceding.Following = element.Following;
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

            return element.data;
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
        #endregion

        #region Private Methods
        private Node<T>? NodeAt(int position)
        {
            if (Head is null || position >= Count || position < 0)
                return null;

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

            if (element.data!.Equals(elementToFind))
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
