// pairprogramming
// fhs37248 Magdalena Wimmer
// fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_huffman {
    internal class HuffmanNode<T> : IComparable {
        internal HuffmanNode(double probability, T value) {
            Probability = probability;
            LeftSon = RightSon = Parent = null;
            Value = value;
            IsLeaf = true;
        }

        internal HuffmanNode(HuffmanNode<T> leftSon, HuffmanNode<T> rightSon) {
            LeftSon = leftSon;
            RightSon = rightSon;
            Probability = leftSon.Probability + rightSon.Probability;
            leftSon.IsZero = true;
            rightSon.IsZero = false;
            leftSon.Parent = rightSon.Parent = this;
            IsLeaf = false;
        }

        internal HuffmanNode<T> LeftSon { get; set; }
        internal HuffmanNode<T> RightSon { get; set; }
        internal HuffmanNode<T> Parent { get; set; }
        internal T Value { get; set; }
        internal bool IsLeaf { get; set; }

        internal bool IsZero { get; set; }

        internal int Bit {
            get { return IsZero ? 0 : 1; }
        }

        internal bool IsRoot {
            get { return Parent == null; }
        }

        internal double Probability { get; set; }

        public int CompareTo(object obj) {
            return -Probability.CompareTo(((HuffmanNode<T>)obj).Probability);
        }
    }

}
