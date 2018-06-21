using System;
using System.Collections.Generic;

namespace Task_8
{  //вершины, соединенные 1 ребром
    public class Edge
    {
        public int v1, v2;

        public Edge(int p1, int p2)
        {
            v1 = p1;
            v2 = p2;
        }
    }
    class Program
    {       
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="count"></param>
       /// <param name="E"></param>
       /// <param name="chains"></param>
        public static void Search(int length, List<Edge> graf, ref List<string> res)
        {
            int[] pick = new int[length];
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                {
                    for (int k = 0; k < length; k++)
                        pick[k] = 1;
                    FindWay(i, j, graf, pick, (i + 2).ToString(), ref res);                    
                }
        }

        /// <summary>
        /// поиск в глубину
        /// </summary>
        /// <param name="a"></param>
        /// <param name="end"></param>
        /// <param name="E"></param>
        /// <param name="pick"></param>
        /// <param name="s"></param>
        /// <param name="res"></param>
        public static void FindWay(int a, int end, List<Edge> E, int[] pick, string s, ref List<string> res)
        {
            if (a != end)//проверка на конечную вершину
                pick[a] = 2;
            else
            {
                res.Add(s);
                return;
            }
            for (int i = 0; i < E.Count; i++)
            {
                if (pick[E[i].v2] == 1 && E[i].v1 == i)
                {
                    FindWay(E[i].v2, end, E, pick, s + "-" + (E[i].v2 + 2).ToString(), ref res);
                    pick[E[i].v2] = 1;
                }
                else if (pick[E[i].v1] == 1 && E[i].v2 == a)
                {
                    FindWay(E[i].v1, end, E, pick, s + "-" + (E[i].v1 + 2).ToString(), ref res);
                    pick[E[i].v1] = 1;
                }
            }
        }
        /// <summary>
        /// Проверка на ввод чисел
        /// </summary>
        /// <returns></returns>
        static int Input()
        {
            int a = 0;
            bool ok;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    ok = true;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите целое число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }

        static void Main(string[] args)
        {            
            List<string> res=new List<string>();// список цепей     
            int v, u, w;//вершины и ребра
            int k = 0;
            Console.Write("Кол. вершин ");
            int n = Input();
            List<Edge> list= new List<Edge>();//список ребер 
            Console.Write("Кол. ребер ");
            int m = Input();
            Console.Write("Вводите ребра и их вес ");

            for (int i = 0; i < m; i++)
            {
                v = Input();
                u = Input();
                w = Input();
                Edge p = new Edge(v-1, u-1);
                list.Add(p);//добавление ребра в список
                         
                Console.WriteLine("...");
            }
            
            bool ok = false;
            Console.WriteLine();
            Search(n, list, ref res);//поиск цепей
            Console.Write("Введите К: ");//кол-во вершин в цепи
            k = Input();
            Console.WriteLine("Цепь, с заданным кол-вом вершин: ");
            for (int i=0; i< res.Count;i++)
            {
                if (res[i].Split('-').Length==k &&ok==false)
                {
                    ok = true;
                    Console.WriteLine(res[i]);
                }
            }
            if(!ok)
            {
                Console.WriteLine("Цепей с {0} вершинами нет", k);
            }           

            Console.ReadKey();


        }
    }
}
