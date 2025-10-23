using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    public class cDate
    {
        private enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        private int[] DayInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int iDay { get; set; }
        public int iMonth { get; set; }
        public int iYear { get; set; }

        public cDate(int iD = 1, int iM = 1, int iY = 1)
        {
            iDay = iD;
            iMonth = iM;
            iYear = iY;
        }
        public cDate(cDate date)
        {
            iDay = date.iDay;
            iMonth = date.iMonth;
            iYear = date.iYear;
        }
        public bool isLeapYear()
        {
            if (iYear % 100 != 0 && iYear % 4 == 0)
                return true;
            else if (iYear % 400 == 0)
                return true;
            else
                return false;
        }
        public bool CheckValid()
        {
            if (iYear < 1)
                return false;
            if (iMonth < 1 || iMonth > 12)
                return false;
            if (isLeapYear())
            {
                DayInMonth[1] = 29;
            }
            else
            {
                DayInMonth[1] = 28;
            }
            switch (iMonth)
            {
                case 1:
                    if (iDay < 1 || iDay > DayInMonth[0])
                        return false;
                    break;
                case 2:
                    if (iDay < 1 || iDay > DayInMonth[1])
                        return false;
                    break;
                case 3:
                    if (iDay < 1 || iDay > DayInMonth[2])
                        return false;
                    break;
                case 4:
                    if (iDay < 1 || iDay > DayInMonth[3])
                        return false;
                    break;
                case 5:
                    if (iDay < 1 || iDay > DayInMonth[4])
                        return false;
                    break;
                case 6:
                    if (iDay < 1 || iDay > DayInMonth[5])
                        return false;
                    break;
                case 7:
                    if (iDay < 1 || iDay > DayInMonth[6])
                        return false;
                    break;
                case 8:
                    if (iDay < 1 || iDay > DayInMonth[7])
                        return false;
                    break;
                case 9:
                    if (iDay < 1 || iDay > DayInMonth[8])
                        return false;
                    break;
                case 10:
                    if (iDay < 1 || iDay > DayInMonth[9])
                        return false;
                    break;
                case 11:
                    if (iDay < 1 || iDay > DayInMonth[10])
                        return false;
                    break;
                case 12:
                    if (iDay < 1 || iDay > DayInMonth[11])
                        return false;
                    break;
                default:
                    break;
            }
            return true;
        }
        public int CheckDayInMonth()
        {
            if (isLeapYear())
            {
                DayInMonth[1] = 29;
            }
            else
            {
                DayInMonth[1] = 28;
            }
            return DayInMonth[iMonth - 1];
        }
        public string CheckDayOfWeek()
        {
            if (isLeapYear())
            {
                DayInMonth[1] = 29;
            }
            else
            {
                DayInMonth[1] = 28;
            }
            int iTotalDay = 0;
            for (int i = 1; i < iYear; i++)
            {
                cDate temp = new cDate(1, 1, i);
                if (temp.isLeapYear())
                    iTotalDay += 366;
                else
                    iTotalDay += 365;
            }
            for (int i = 1; i < iMonth; i++)
            {
                iTotalDay += DayInMonth[i - 1];
            }
            iTotalDay += iDay;
            int iDoW = iTotalDay % 7;
            switch (iDoW)
            {
                case 0:
                    return "Sun";
                case 1:
                    return "Mon";
                case 2:
                    return "Tue";
                case 3:
                    return "Wed";
                case 4:
                    return "Thu";
                case 5:
                    return "Fri";
                case 6:
                    return "Sat";
                default:
                    return "Khong xac dinh";
            }
        }
        public void Input()
        {
            int Month, Year;
            while (true)
            {
                Console.Write("Month (MM/YYYY): ");
                string inputMonth = Console.ReadLine();
                if (inputMonth == null)
                {
                    Console.WriteLine("Invalid input.");
                    continue;

                }
                else if (!inputMonth.Contains('/'))
                {
                    Console.WriteLine("Invalid format. Please use MM/YYYY format.");
                    continue;
                }
                else
                {
                    string[] partsMonth = inputMonth.Split('/');
                    string calendarMonth = partsMonth[0];
                    string calendarYear = partsMonth[1];
                    if (int.TryParse(calendarMonth, out Month) && int.TryParse(calendarYear, out Year))
                    {
                        if (Month < 1 || Month > 12 || Year < 1)
                        {
                            Console.WriteLine("Invalid month or year. Please enter a valid month (1-12) and a positive year.");
                            continue;
                        }
                        else
                        {
                            iMonth = Month;
                            iYear = Year;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter numeric values for month and year.");
                        continue;
                    }
                }
            }
        }
        public void PrintCalendar()
        {
            Console.WriteLine("Calendar for {0}/{1}", iMonth, iYear);
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
            int daysInMonth = CheckDayInMonth();
            cDate firstDayOfMonth = new cDate(1, iMonth, iYear);
            int firstDayOfWeek = (firstDayOfMonth.CheckDayOfWeek() == "Sun") ? 0 :
                                 (firstDayOfMonth.CheckDayOfWeek() == "Mon") ? 1 :
                                 (firstDayOfMonth.CheckDayOfWeek() == "Tue") ? 2 :
                                 (firstDayOfMonth.CheckDayOfWeek() == "Wed") ? 3 :
                                 (firstDayOfMonth.CheckDayOfWeek() == "Thu") ? 4 :
                                 (firstDayOfMonth.CheckDayOfWeek() == "Fri") ? 5 : 6;
            for (int i = 0; i < firstDayOfWeek; i++)
            {
                Console.Write("\t");
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write("{0}\t", day);
                if ((day + firstDayOfWeek) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }

    public class B1
    {
        public void Run()
        {
            cDate a = new cDate();
            a.Input();
            a.PrintCalendar();
        }
    }
}
