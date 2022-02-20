using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminárka_ALG
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 3, 2, -7, 44, 5, 1, 0, -3 };
            int[] tab1 = { 1, 4, 6, 18, 20, 23, 29, 32, 34, 39, 40, 41 };
                
            Console.WriteLine("Nesetříděné pole pro lineární vyhledávání");
            Vypis(tab);
            Console.WriteLine("Setříděné pole pro binární vyhledávání");
            Vypis(tab1);

            Console.WriteLine();

            #region FIFO
            Console.WriteLine("---------------------FIFO fronta------------------");
            Queue<int> fifo = new Queue<int>();
            Console.WriteLine("Vlozím do fronty 1 poté 2 a 3, a první číslo které se mi vrátí je 1");
            fifo.Enqueue(1);
            fifo.Enqueue(2);
            fifo.Enqueue(3);

            Console.WriteLine(fifo.Dequeue());
            #endregion

            #region LIFO
            Console.WriteLine("---------------------LIFO fronta------------------");
            Stack<int> lifo = new Stack<int>();
            Console.WriteLine("Vlozím do zásobníku 1 poté 2 a 3, a první číslo které se mi vrátí je 3");
            lifo.Push(1);
            lifo.Push(2);
            lifo.Push(3);

            Console.WriteLine(lifo.Pop());
            #endregion

            #region Spojový seznam
            Console.WriteLine("-------------------Spojový seznam-----------------");
            LinkedList<int> seznam = new LinkedList<int>();
            seznam.AddFirst(1);
            seznam.AddLast(2);
            LinkedListNode<int> prostredni = seznam.AddLast(3);
            seznam.AddLast(4);
            seznam.AddLast(5);
            seznam.AddAfter(prostredni, 32);
            seznam.AddAfter(prostredni, 31);
            seznam.Remove(prostredni);
            foreach (int i in seznam)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            #endregion

            #region Linear
            Console.WriteLine("-------------Lineární vyhledávání-------------");
            Console.WriteLine("hledám index čísla 7");
            Console.WriteLine(Linear(tab, 7));
            Console.WriteLine("hledám index čísla -7");
            Console.WriteLine(Linear(tab, -7));
            #endregion

            #region Binary_rek
            Console.WriteLine("-------------Binární vyhledávání s rekurzí-------------");
            Console.WriteLine("hledám index čísla 21");
            Console.WriteLine(Binary_rek(tab1, 21, 0, 13));
            Console.WriteLine("hledám index čísla 40");
            Console.WriteLine(Binary_rek(tab1, 40, 0, 13));
            #endregion

            #region binary
            Console.WriteLine("-------------Binární vyhledávání bez rekurze-------------");
            Console.WriteLine("hledám index čísla 25");
            Console.WriteLine(Binary(tab1, 25));
            Console.WriteLine("hledám index čísla 29");
            Console.WriteLine(Binary(tab1, 29));
            #endregion

            Console.ReadKey();
        }

        #region Linear
        static int Linear(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Binary_rek
        static int Binary_rek(int[] arr, int x, int left, int right)
        {
            if (left > right)
            {
                return -1; // prvek nebyl nalezen
            }
            int mid = (left + right) / 2;
            if (arr[mid] == x)
            {
                return mid; //prvek byl nalezen
            }
            else if (x < arr[mid])
            {
                return Binary_rek(arr, x, left, mid - 1);
            }
            else
            {
                return Binary_rek(arr, x, mid + 1, right);
            }
        }
        #endregion

        #region Binary
        enum Nalezeno { ANO, NE };
        static int Binary(int[] arr, int x)
        {
            Nalezeno nalezeno = Nalezeno.NE;
            int left = 0;
            int right = arr.Length - 1;
            int mid = 0;

            while ((left <= right) && nalezeno != Nalezeno.ANO)
            {
                mid = (left + right) / 2;
                if (arr[mid] == x)
                {
                    nalezeno = Nalezeno.ANO;
                }
                else
                {
                    if (arr[mid] < x)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            if (nalezeno == Nalezeno.ANO)
                return mid; // prvek byl nalezen, vrátí index prvku
            else
                return -1; // prvek nebyl nalezen, vrátí -1
        }
        #endregion

        #region Vypis
        static void Vypis(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}

