using System;
using System.Collections;


namespace OOP_LAB7
{
    public class FloatList : IEnumerable  
    {
        Node head; // first elem
        Node tail; // last elem
        public int Count { get; private set; }
        public bool IsEmpty { get { return Count == 0; } }

        // Adding new element at the end of list
        public void Add(float data)
        {
            Node node = new Node(data);
            node.Next = head;
            head = node;

            if (Count == 0)
                tail = head;

            Count++;
        }
        // Removing element
        public bool Remove(float data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(float data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public int BiggerThanAverage()
        {
            float average = 0;
            float sum = 0;
            int amount = 0;

            Node current = head;

            while(current != null)
            {
                sum += current.Data;
                current = current.Next;
            }
            average = sum / Count;

            current = head;
            while (current != null)
            {
                if (current.Data > average)
                    amount++;
                current = current.Next;
            }

            return amount;
        }

        public void DeleteAllNegativeNums()
        {
            Node current = head;

            for(int i = 0; i < Count; i++)
            {
                if (current.Data < 0)
                {
                    Remove(current.Data);
                    i--;
                }

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
