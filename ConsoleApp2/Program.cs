using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Solution
    {
        List<int[]> usingRoom = new List<int[]>();
        int max = 0;

        static void Main(string[] args)
        {
            string[,] book_time = {
            { "15:00", "17:00" },
            { "16:40", "18:20" },
            { "14:20", "15:20" },
            { "14:10", "19:20" },
            { "18:20", "21:20" } };
            Solution A = new Solution();
            A.solution(book_time);
            
            Console.ReadLine();
        }
        public int solution(string[,] book_time)
        {
            int answer = 0;
            int repeat = 0;
            int maxRoomCount = 0;
            List<int[]> blist = new List<int[]>();
            //List<int[]> usingRoom = new List<int[]>();
            int finish = 0;
            book_time = new string[,]{
            { "15:00", "17:00" },
            { "16:40", "18:20" },
            { "14:20", "15:20" },
            { "14:10", "19:20" },
            { "18:20", "21:20" } };
            for (int i = 0; i < book_time.GetLength(0); i++) 
            {
                int[] temp = new int[2];
                book_time[i, 0]=book_time[i, 0].Replace(":","");
                book_time[i, 1]=book_time[i, 1].Replace(":","");
                temp[0] = int.Parse(book_time[i,0]);
                finish =int.Parse(book_time[i, 1])+10;//분계산
                if (finish % 100 > 59)
                {
                    finish =finish+ 40;
                }
                temp[1] = finish;
                blist.Add((temp));
                //Console.WriteLine(temp[0]);
            }
            blist.Sort((x, y) => x[0].CompareTo(y[0]));
            for (int i = 0; i < blist.Count; i++)
            {
                roomcheck(blist[i]);
            }
            Console.WriteLine(max);
            return answer;
        }
        public void roomcheck(int[] insertRoom) 
        {
            usingRoom.Add(insertRoom);
            for (int i = 0; i < usingRoom.Count; i++) 
            {
                if (usingRoom[i][1] < insertRoom[0]) 
                {
                    usingRoom.RemoveAt(i);
                    i--;
                }
            }
            if (max < usingRoom.Count) 
            {
                max = usingRoom.Count;
            }

        }
    }
}
