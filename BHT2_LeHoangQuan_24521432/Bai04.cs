using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class PhanSo
    {
        internal int iTuSo { get; set; }
        internal int iMauSo { get; set; }
        internal PhanSo(int iTu = 0, int iMau = 1)
        {
            iTuSo = iTu;
            iMauSo = iMau;
        }
        public PhanSo(PhanSo PS)
        {
            iTuSo = PS.iTuSo;
            iMauSo = PS.iMauSo;
        }
        public void Input()
        {
            string temp;
            int iTu, iMau;
            while (true)
            {
                Console.Write("Nhap tu so: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out iTu))
                {
                    iTuSo = (int)iTu;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            while (true)
            {
                Console.Write("Nhap mau so: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out iMau))
                {
                    iMauSo = (int)iMau;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
        }
        public string Output()
        {
            if (iTuSo % iMauSo == 0)
                return((iTuSo/iMauSo).ToString());
            else if (iMauSo < 0)
                return((iTuSo*-1).ToString() +  "/" + (iMauSo*-1).ToString());
            else
                return(iTuSo + "/" + iMauSo);
        }
        public static int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public double getGiaTri() => ((double)(1.0 * iTuSo/iMauSo));
        public void RutGon()
        {
            int ucln = UCLN(iTuSo, iMauSo);
            iTuSo /= ucln;
            iMauSo /= ucln;
        }
        public static PhanSo operator+(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.iTuSo = a.iTuSo * b.iMauSo + a.iMauSo * b.iTuSo;
            c.iMauSo = a.iMauSo * b.iMauSo;
            c.RutGon();
            return c;
        }
        public static PhanSo operator-(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.iTuSo = a.iTuSo * b.iMauSo - a.iMauSo * b.iTuSo;
            c.iMauSo = a.iMauSo * b.iMauSo;
            c.RutGon();
            return c;
        }
        public static PhanSo operator*(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.iTuSo = a.iTuSo * b.iTuSo;
            c.iMauSo = a.iMauSo * b.iMauSo;
            c.RutGon();
            return c;
        }
        public static PhanSo operator/(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            try
            {
                c.iTuSo = a.iTuSo * b.iMauSo;
                c.iMauSo = a.iMauSo * b.iTuSo;
                c.RutGon();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Khong the chia cho 0!");
            }
           return c;
        }
    }
    internal class DayPhanSo
    {
        internal List<PhanSo> Day = new List<PhanSo> ();
        public DayPhanSo(int n = 1)
        {
            for (int i = 0; i < n; i++)
                Day.Add(new PhanSo(i));
        }
        private void DoiCho(ref PhanSo a, ref PhanSo b)
        {
            PhanSo phanSo = a;
            a = b;
            b = phanSo;
        }
        public void Input()
        {
            Day.Clear();
            string temp;
            int n;
            while (true)
            {
                Console.Write("Nhap so luong phan so: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            for (int i = 0; i < n; i++)
            {
                PhanSo PS = new PhanSo();
                Console.WriteLine("Nhap phan so thu {0}", i + 1);
                PS.Input();
                Day.Add(PS);
            }
        }
        public void Output()
        {
            Console.Write("Day phan so: ");
            for (int i = 0; i < Day.Count; i++)
            {
                Console.Write(Day[i].Output());
                if (i == Day.Count - 1)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Write(", ");
            }
        }
        public List<PhanSo> TimPhanSoLonNhat()
        {
            List<PhanSo> result = new List<PhanSo>();
            PhanSo max = Day[0];
            for (int i = 1; i < Day.Count; i++)
            {
                if (max.getGiaTri() < Day[i].getGiaTri())
                {
                    result.Clear();
                    result.Add(Day[i]);
                    max = Day[i];
                }
                else if (max.getGiaTri() == Day[i].getGiaTri())
                    result.Add(Day[i]);
            }
            return result;
        }
        private void QuickSort(int l, int r)
        {
            if (l >  r)
                return;
            int i = l;
            int j = r;
            PhanSo pivot = Day[l + (r - l)/2];
            while (i <= j)
            {
                while (Day[i].getGiaTri() < pivot.getGiaTri())
                    i++;
                while (Day[j].getGiaTri() > pivot.getGiaTri())
                    j--;
                if (i <= j)
                {
                    PhanSo temp = Day[i];
                    PhanSo temp1 = Day[j];
                    DoiCho(ref temp, ref temp1);
                    Day[i] = temp;
                    Day[j] = temp1;
                    i++;
                    j--;
                }
            }
            QuickSort(l,j);
            QuickSort(i, r);
        }
        public void SapXep()
        {
            QuickSort(0, Day.Count - 1);
        }
    }
    public class B4
    {
        public void Run()
        {
            //Console.WriteLine("Nhap phan so 1");
            //PhanSo ps1 = new PhanSo();
            //ps1.Input();
            //Console.WriteLine("Nhap phan so 2");
            //PhanSo ps2 = new PhanSo();
            //ps2.Input();
            //Console.WriteLine($"{ps1.Output()} + {ps2.Output()} = {(ps1 + ps2).Output()}");
            //Console.WriteLine($"{ps1.Output()} - {ps2.Output()} = {(ps1 - ps2).Output()}");
            //Console.WriteLine($"{ps1.Output()} * {ps2.Output()} = {(ps1 * ps2).Output()}");
            //Console.WriteLine($"{ps1.Output()} / {ps2.Output()} = {(ps1 / ps2).Output()}");
            DayPhanSo dayPhanSo = new DayPhanSo();
            dayPhanSo.Input();
            dayPhanSo.Output();
            Console.Write("Phan so lon nhat: ");
            List<PhanSo> max = dayPhanSo.TimPhanSoLonNhat();
            for (int i = 0; i < max.Count; i++)
            {
                Console.Write(max[i].Output());
                if (i == max.Count - 1)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Write(", ");
            }
            Console.WriteLine("Dang sap day phan so tang...");
            dayPhanSo.SapXep();
            dayPhanSo.Output();

        }
    }
}
