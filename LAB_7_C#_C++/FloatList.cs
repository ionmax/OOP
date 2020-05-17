using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB7
{
    class FloatList : IEnumerable
    {
        private float[] floatlist = null;
        private int position = -1;
        public int Count { private set; get; }

        public float this[int index]
        {
            get { return floatlist[index]; }
            set { floatlist[index] = value; }
        }

        public FloatList()
        {
            Count = 0;
        }

        public void Add(float num)
        {
            float[] newList = new float[Count + 1];

            Count++;
            newList[0] = num;
            
            for(int i = 1; i < Count; i++)
            {
                newList[i] = floatlist[i - 1];
            }

            floatlist = newList;
        }

        public int Find(float num)
        {
            for (int i = 0; i < Count; i++)
                if (num == floatlist[i])
                    return i;
            return -1;
        }

        public void Remove(float num)
        {
            int index = Find(num);

            if (index == -1)
                return;

            float[] newList = new float[--Count];

            for (int i = 0; i < index; i++)
                newList[i] = floatlist[i];

            for (int i = index; i < Count; i++)
                newList[i] = floatlist[i + 1];

            floatlist = newList;
        }

        public int BiggerThanAverage()
        {
            if (Count < 2)
                return 0;

            int amount = 0;
            float average;
            float[] list = new float[Count];

            Array.Copy(floatlist, list, Count);
            Array.Sort(list);

            average = list[Count / 2];

            foreach (float elem in floatlist)
                if (elem > average)
                    amount++;

            return amount;
        }

        public void DeleteAllNegativeNums()
        {
            for(int i = 0; i < Count; i++)
            {
                if (floatlist[i] < 0)
                {
                    Remove(floatlist[i]);
                    i--;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            while(true)
            {
                if (position < floatlist.Length - 1)
                {
                    position++;
                    yield return floatlist[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        private void Reset()
        {
            position = -1;
        }
    }
}
