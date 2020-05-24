using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB7
{
    public class Node
    {
        public float Data { get; set; }
        public Node Next { get; set; }

        public Node(float data) => Data = data;
    }
}
