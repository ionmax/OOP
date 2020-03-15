using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStringText
{
    public class MyString
    {
        public MyString()
        {
            MyStr = new char[0];
            length = 0;
        }

        public MyString(char[] str)
        {
            MyStr = str;
            length = str.Length;
        }

        public MyString(int i)
        {
            MyStr = new char[i];
            length = i;
        }

        //For calling operator "[]"
        public char this[int i]
        {
            get => MyStr[i];
            set => MyStr[i] = value;
        }

        //Printing the string
        public void Print()
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write(MyStr[j]);
            }
        }

        public char[] MyStr;
        public int length;
    }


    public class Text
    {
        public int length = 0;
        public List<MyString> text = new List<MyString>();

        //Adding MyString object in vector
        public void AddStr(MyString strToAdd)
        {
            text.Add(strToAdd);
            length++;
        }

        //Deleting MyString object from vector
        public void DeleteStr(int strToDel)
        {
            text.RemoveAt(strToDel - 1);
            length--;
        }

        //Clearing Text
        public void CleatText()
        {
            text.Clear();
            length = 0;
        }

        //Making first letters to upper register
        public void MyToUpper()
        {
            for (int i = 0; i < length; i++)
            {
                text[i][0] = (char.ToUpper(text[i][0]));
            }
        }

        //Find a key(the word that contain from first letters of the strings)
        public MyString TakeAKey()
        {
            MyString Key = new MyString(length);
            for (int i = 0; i < length; i++)
            {
                Key[i] = text[i][0];
            }

            return Key;
        }

        //Return amount of string with the number of chars
        public int TheLength(int amount)
        {
            int quantity = 0;
            for (int i = 0; i < length; i++)
            {
                if (text[i].length == amount)
                {
                    quantity++;
                }
            }

            return quantity;
        }

        //For calling operator "[]"
        public MyString ReturnTheString(int i)
        {
            return text[i];
        }

        //Printing 'i' element of vector
        public void Print(int i)
        {
            text[i].Print();
        }

        //Printing whole vector
        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                Print(i);
            }
        }
    }
}
