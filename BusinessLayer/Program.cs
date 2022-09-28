using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopService.Instance.ReadDataShop();
            //for(int i = 1; i <= 31; i++)
            //{
            //    for(int j = 2; j <= 18; j++)
            //    {
            //        AddTimeOneDay(j, i);
                    
            //    }
                
            //}
            
        }

        static void AddTimeOneDay(int id, int day)
        {
            DateTime startTime = new DateTime(2021, 12, day, 6, 0, 0);

            while (startTime.Day < (day + 1) && startTime.Hour < 22)
            {
                DateTime timeNext = startTime.Add(new TimeSpan(1, 0, 0));
                int status = 0;
                if(startTime.Subtract(DateTime.Now).TotalSeconds < 0)
                {
                    status = 2;
                }
                TimeTableService.Instance.TimeTableInsert(startTime, timeNext, id, status);
                Console.WriteLine(string.Format("Add Done: {0} to {1}", startTime.ToString(), timeNext.ToString()));
                startTime = timeNext;

            }



        }
    }
}
