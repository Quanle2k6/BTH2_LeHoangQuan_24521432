using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHT2_LeHoangQuan_24521432
{
    internal class Bai01
    {

    }
    public class Date
    {
        public short Day {  get; set; }
        public short Month { get; set; }
        public int Year { get; set; }

        public Date(short day = 1, short month = 1, int year = 1)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
        public Date(Date date)
        {
            this.Day= date.Day;
            this.Month = date.Month;
            this.Year = date.Year;
        }

    }
}
