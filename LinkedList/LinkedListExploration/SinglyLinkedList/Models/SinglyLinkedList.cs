﻿using System.Runtime.CompilerServices;

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
            Head = KReverse(groupCount, Head);
        }

        public Node<T>? StartingOfTheLoop()
        {
            var pointOfIntersection = PointOfIntersection();
            if (pointOfIntersection is null)
                return null;

            var slow = Head;

            while (slow != pointOfIntersection)
            {
                slow = slow?.Following;
                pointOfIntersection = pointOfIntersection?.Following;
            }

            return slow;
        }

        public void DetachLoop()
        {
            var startingOfLoop = StartingOfTheLoop();
            if (startingOfLoop is null)
                return;

            var node = startingOfLoop;

            while (node?.Following != startingOfLoop)
            {
                node = node?.Following;
            }

            node.Following = null;
        }

        public void RemoveDuplicatesFromSortedLL()
        {
            if (Head is null)
                return;

            Node<T>? current = Head;
            Node<T>? following = current.Following;

            while (current != null && following != null)
            {
                if (current.Data!.Equals(following.Data))
                {
                    current.Following = following.Following;
                    Count--;
                }

                current = current.Following;
                following = current?.Following;
            }
        }

        /// <summary>
        ///  Time: O(n)
        ///  Space: O(n)
        /// </summary>
        public void RemoveDuplicatesFromUnSortedLLUsingHashSet()
        {
            if (Head is null)
                return;

            HashSet<T> hashSet = new();

            Node<T>? current = Head;
            Node<T>? preceding = Head;

            while (current != null)
            {
                if (hashSet.Contains(current.Data))
                {
                    preceding.Following = current.Following;
                    Count--;
                }
                else
                {
                    hashSet.Add(current.Data);
                    preceding = current;
                }
                current = current.Following;
            }
        }

        public void RemoveDuplicatesFromUnSortedLLUsingNestedLoop()
        {
            if (Head is null)
                return;

            Node<T>? current = Head;

            while (current != null)
            {
                Node<T>? temp = current.Following;
                Node<T>? preceding = current;
                while (temp != null)
                {
                    if (current.Data!.Equals(temp.Data))
                    {
                        preceding.Following = temp.Following;
                        Count--;
                    }
                    else
                    {
                        preceding = temp;
                    }
                    temp = temp.Following;
                }

                current = current.Following;
            }
        }
        #endregion

        #region Private Methods
        private Node<T>? PointOfIntersection()
        {
            if (Head is null)
                return null;

            Node<T>? slow = Head;
            Node<T>? fast = Head;

            while (slow != null && fast != null)
            {
                slow = slow.Following;
                fast = fast.Following?.Following;

                if (slow == fast)
                    return slow;
            }

            return null;
        }

        private Node<T>? KReverse(int k, Node<T>? head)
        {
            if (head is null)
                return head;

            // step 1: reverse a first k nodes
            Node<T>? preceding = null;
            Node<T>? current = head;
            Node<T>? following = null;
            int count = 0;

            while (current != null && count < k)
            {
                following = current.Following;
                current.Following = preceding;
                preceding = current;
                current = following;
                count++;
            }

            if (following is not null)
                head.Following = KReverse(k, following);

            return preceding;
        }

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
