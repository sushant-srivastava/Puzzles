/*
 * Created by SharpDevelop.
 * User: srivas4
 * Date: 4/8/2011
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Sudoku
{
	class Program
    {
        static int[,] inp = new int[9, 9];
        static void ResetGrid()
        {

            string str = @"
                        9,7,0,2,1,0,0,0,0,
                        5,0,0,0,0,0,0,0,0,
                        3,6,0,0,0,0,0,4,8,
                        0,0,3,0,9,0,5,0,0,
                        0,0,7,0,0,0,1,0,0,
                        0,0,4,0,6,0,3,0,0,
                        2,8,0,0,0,0,0,3,5,
                        0,0,0,0,0,0,0,0,9,
                        0,0,0,0,3,7,0,6,2";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    inp[i, j] = int.Parse(str.Split(',')[i * 9 + j]);
                }
            }
        }
        static void Main(string[] args)
        {
ResetGrid();            
            while(!checkComplete(inp))
                GetLocation(inp);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)                
                    Console.Write(inp[i, j].ToString() + "  ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static bool checkComplete(int[,] num)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (num[i, j] == 0)
                        return false;
            return true;
        }
        
        static void GetLocation(int[,] num)
        {   
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    List<int> lst = GetMoves(num, i, j);
                    if (lst.Count == 0)
                        continue;
                    if (inp[i, j] == 0)
                    {
                        if (predictMoves(lst, i, j))
                            return;
                    }
                }
            }            
        }
        
        static bool predictMoves(List<int> x,int i,int j)
        {
            for (int k = 1; k < 10; k++)
            {
                if (!x.Contains(k))
                {
                    inp[i, j] = k;
                    position p = GetNextPosition();
                    if(((p.x+p.y)==0)&&(checkComplete(inp)))
                        return true;
                    predictMoves(GetMoves(inp, p.x, p.y), p.x, p.y);
                    inp[i,j]=0;
                }    
            }        
            return false;
        }
        static position GetNextPosition()
        {
            position p;
            p.x = 0;
            p.y = 0;
            int max = 0;
            for(int i=0;i<9;i++)
                for (int j = 0; j < 9; j++)
                {
                    if (inp[i, j] == 0)
                    {
                        List<int> lst = GetMoves(inp, i, j);
                        if (max < lst.Count)
                        {
                            max = lst.Count;
                            p.x = i;
                            p.y = j;
                        }
                    }
                }
            return p;
        }
        static List<int> GetMoves(int[,] num, int i, int j)
        {
            List<int> lst = new List<int>();
            if (num[i, j] != 0)
                return lst;                        
            for (int k = 0; k < 9; k++)
            {
                if ((inp[k, j] != 0) && (!lst.Contains(inp[k, j])))
                    lst.Add(inp[k, j]);
            }
            for (int k = 0; k < 9; k++)
            {
                if ((inp[i, k] != 0) && (!lst.Contains(inp[i, k])))
                    lst.Add(inp[i, k]);
            }
            int temp = i * 9 + j;
            if ((i >= 0) && (i < 3) && (j >= 0) && (j < 3))
            {
                for (int l = 0; l < 3; l++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 3) && (i < 6) && (j >= 0) && (j < 3))
            {
                for (int l = 3; l < 6; l++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 6) && (i < 9) && (j >= 0) && (j < 3))
            {
                for (int l = 6; l < 9; l++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 0) && (i < 3) && (j >= 3) && (j < 6))
            {
                for (int l = 0; l < 3; l++)
                {
                    for (int m = 3; m < 6; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 3) && (i < 6) && (j >= 3) && (j < 6))
            {
                for (int l = 3; l < 6; l++)
                {
                    for (int m = 3; m < 6; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 6) && (i < 9) && (j >= 3) && (j < 6))
            {
                for (int l = 6; l < 9; l++)
                {
                    for (int m = 3; m < 6; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 0) && (i < 3) && (j >= 6) && (j < 9))
            {
                for (int l = 0; l < 3; l++)
                {
                    for (int m = 6; m < 9; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 3) && (i < 6) && (j >= 6) && (j < 9))
            {
                for (int l = 3; l < 6; l++)
                {
                    for (int m = 6; m < 9; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            if ((i >= 6) && (i < 9) && (j >= 6) && (j < 9))
            {
                for (int l = 6; l < 9; l++)
                {
                    for (int m = 6; m < 9; m++)
                    {
                        if ((!lst.Contains(inp[l, m])) && inp[l, m] != 0)
                            lst.Add(inp[l, m]);
                    }
                }
            }
            return lst;
        }
       
    }
    struct position
    {
        public int x;
        public int y;
    }

}