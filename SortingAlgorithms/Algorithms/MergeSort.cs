using System;
using System.Threading;

namespace SortingAlgorithms.Algorithms
{
    public class MergeSortAl : ISortAlgorithm
    {
        Random rnd = new Random();
        public string Name { get; set; }

        public MergeSortAl(string name)
        {  
            Name = name;
        }

        public int[] Sort(int[] buff, int brushPosX, int brushPosY)
        {
            
            Console.SetCursorPosition(brushPosX, brushPosY);
            Console.Write(WriteArr(buff));
            if (buff.Length > 1)
            {
                int[] left = new int[buff.Length / 2];

                int[] right = new int[buff.Length - left.Length];

                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = buff[i];
                }
                
                //Console.Write("\t\t\t");
                for(int i = 0; i < right.Length; i++)
                {
                    right[i] = buff[left.Length + i];
                }
                
                Thread.Sleep(1000);
                if (left.Length > 1)
                {
                    left = Sort(left, brushPosX, brushPosY + 1);                 
                }
                    
                if (right.Length > 1)
                {
                    right = Sort(right, brushPosX + right.Length * 4 + 1, brushPosY + 1);              
                }

                
                //Console.Write(WriteArr(left) + " " + WriteArr(right));
                buff = MergeSort(left, right);
                Console.SetCursorPosition(brushPosX, brushPosY + buff.Length -1);
                Console.Write(WriteArr(buff));
            }

            return buff;
        }// Sort();

        static int[] MergeSort(int[] left, int[] right)
        {
            int[] buff = new int[left.Length + right.Length];

            int i = 0;
            int l = 0;
            int r = 0;

            for(;i < buff.Length; i++)
            {
                if (r >= right.Length)
                {
                    buff[i] = left[l];
                    l++;
                }
                else if (l < left.Length && left[l] < right[r])
                {
                    buff[i] = left[l];
                    l++;
                }
                else
                {
                    buff[i] = right[r];
                    r++;
                }
            }

            return buff;
        }

        static string WriteArr(int[] arr)
        {
            string str = "";
            foreach(int i in arr)
            {
                str += i.ToString() + " ";
            }
            return str;
        }

        public void Sort()
        {
            Sort(ArrayGenerator.Generate(16, 1, 100), 0, 0);
        }
    }
}
