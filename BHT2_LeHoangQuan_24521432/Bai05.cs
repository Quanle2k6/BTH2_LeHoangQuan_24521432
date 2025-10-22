using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    public class KhuDat
    {
        internal string DiaDiem { get; set; }
        internal long Gia { get; set; }
        internal double DienTich { get; set; }
        public KhuDat(string diadiem = "", long gia = 0, double dienTich = 0)
        {
            DiaDiem = diadiem;
            Gia = gia;
            DienTich = dienTich;
        }
        public virtual void Input()
        {
            while (true)
            {
                Console.Write("Nhap dia chi: ");
                DiaDiem = Console.ReadLine();
                if (DiaDiem != null && DiaDiem.Trim() != "")
                    break;
                Console.WriteLine("Data can't be empty!");
            }
            while (true)
            {
                Console.Write("Nhap gia: ");
                string temp = Console.ReadLine();
                long temp1;
                if (long.TryParse(temp, out temp1) && temp1 >= 0)
                {
                    Gia = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            while (true)
            {
                Console.Write("Nhap dien tich: ");
                string temp = Console.ReadLine();
                double temp1;
                if (double.TryParse(temp, out temp1) && temp1 >= 0)
                {
                    DienTich = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
        }
        public virtual void Output()
        {
            Console.WriteLine($"Dia diem: {DiaDiem}");
            Console.WriteLine($"Gia ban: {Gia}");
            Console.WriteLine($"Dien tich: {DienTich}");
        }
    }
    public class NhaPho : KhuDat
    {
        internal int NamXay { get; set; }
        internal int SoTang { get; set; }
        public NhaPho(string diadiem = "", long gia = 0, double dienTich = 0, int namxay = 0, int sotang = 0)
        {
            DiaDiem = diadiem;
            Gia = gia;
            DienTich = dienTich; NamXay = namxay;
            SoTang = sotang;
        }
        public override void Input()
        {
            base.Input();
            while (true)
            {
                Console.Write("Nhap nam xay dung: ");
                string temp = Console.ReadLine();
                int temp1;
                if (int.TryParse(temp, out temp1) && temp1 > 0)
                {
                    NamXay = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            while (true)
            {
                Console.Write("Nhap so tang: ");
                string temp = Console.ReadLine();
                int temp1;
                if (int.TryParse(temp, out temp1) && temp1 > 0)
                {
                    SoTang = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Nam xay dung: {NamXay}");
            Console.WriteLine($"So tang: {SoTang}");
        }
    }
    public class ChungCu : KhuDat
    {
        internal int Tang { get; set; }
        public ChungCu(string diadiem = "", long gia = 0, double dienTich = 0, int tang = 0)
        {
            DiaDiem = diadiem;
            Gia = gia;
            DienTich = dienTich;
            Tang = tang;
        }
        public override void Input()
        {
            base.Input();
            while (true)
            {
                Console.Write("Nhap tang: ");
                string temp = Console.ReadLine();
                int temp1;
                if (int.TryParse(temp, out temp1) && temp1 > 0)
                {
                   Tang = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"So tang: {Tang}");
        }
    }
    public class DSBatDongSan: KhuDat
    {
        internal List<KhuDat> DanhSachBatDongSan = new List<KhuDat>();
        public void InputList()
        {
            while (true)
            {
                Console.Write("Nhap so luong bat dong san: ");
                string temp = Console.ReadLine();
                long temp1;
                if (long.TryParse(temp, out temp1) && temp1 > 0)
                {
                    for (int i = 0; i < temp1; i++)
                    {
                        Console.WriteLine($"Nhap thong tin bat dong san {i + 1}");
                        string loai;
                        while (true)
                        {
                            Console.Write("Nhap loai bat dong san (0: Khu Dat, 1: Nha Pho, 2: Chung Cu): ");
                            loai = Console.ReadLine();
                            if (loai == "0" || loai == "1" || loai == "2")
                            {
                                break;
                            }
                            Console.WriteLine("Error Valid Number.");
                        }
                        KhuDat batDongSan = new KhuDat();
                        switch (loai)
                        {
                            case "0":
                                batDongSan = new KhuDat();
                                batDongSan.Input();
                                break;
                            case "1":
                                batDongSan = new NhaPho();
                                batDongSan.Input();
                                break;
                            case "2":
                                batDongSan = new ChungCu();
                                batDongSan.Input();
                                break;
                            default:
                                Console.WriteLine("Error Valid Number.");
                                i--;
                                continue;
                        }
                        DanhSachBatDongSan.Add(batDongSan);
                    }
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
        }

        public void OutputList()
        {
            for (int i = 0; i < DanhSachBatDongSan.Count; i++)
            {
                Console.WriteLine($"Bat dong san {i + 1}");
                DanhSachBatDongSan[i].Output();
            }
        }
        public long TinhTongGiaDat()
        {
            long TongGiaDat = 0;
            for (int i = 0; i < DanhSachBatDongSan.Count; i++)
            {
                if (DanhSachBatDongSan[i] is KhuDat && !(DanhSachBatDongSan[i] is NhaPho) && !(DanhSachBatDongSan[i] is ChungCu))
                    TongGiaDat += DanhSachBatDongSan[i].Gia;
            }
            return TongGiaDat;
        }
        public long TinhTongGiaNhaPho()
        {
            long TongGiaNhaPho = 0;
            for (int i = 0; i < DanhSachBatDongSan.Count; i++)
            {
                if (DanhSachBatDongSan[i] is NhaPho)
                    TongGiaNhaPho += DanhSachBatDongSan[i].Gia;
            }
            return TongGiaNhaPho;
        }
        public long TinhTongGiaChungCu()
        {
            long TongGiaChungCu = 0;
            for (int i = 0; i < DanhSachBatDongSan.Count; i++)
            {
                if (DanhSachBatDongSan[i] is ChungCu)
                    TongGiaChungCu += DanhSachBatDongSan[i].Gia;
            }
            return TongGiaChungCu;
        }
        public void XuatTheoYeuCau()
        {
            List <KhuDat> result = new List<KhuDat> ();
            foreach (var bds in DanhSachBatDongSan)
            {
                if (bds is KhuDat kd && !(bds is NhaPho) && !(bds is ChungCu) && kd.DienTich > 100)
                    result.Add(bds);
                else if (bds is NhaPho np && np.DienTich > 60 && np.NamXay >= 2019)
                    result.Add(bds);
            }
            if (result.Count > 0)
            {
                Console.WriteLine("Danh sach thoa dieu kien: ");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"Ket qua {i + 1}: ");
                    result[i].Output();
                }
            }
            else
            {
                Console.WriteLine("Khong co ket qua nao thoa.");
            }
        }
        public void TimKiem(string diadiem = "", long gia = 0, double dientich = 0)
        {
            List<KhuDat> result = new List<KhuDat>();
            foreach (var bds in DanhSachBatDongSan)
            {
                if (string.Equals(bds.DiaDiem, diadiem, StringComparison.OrdinalIgnoreCase) && bds.Gia <= gia && bds.DienTich >= dientich)
                {
                    result.Add(bds);
                }
            }
            if (result.Count > 0)
            {
                Console.WriteLine("Danh sach tim thay: ");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"Ket qua {i + 1}: ");
                    result[i].Output();
                }
            }
            else
            {
                Console.WriteLine("Khong co ket qua nao thoa.");
            }
        }

    }

    public class B5
    {
        public void Run()
        {
            DSBatDongSan ds = new DSBatDongSan();
            ds.InputList();
            Console.WriteLine("\n---Danh sach bat dong san---");
            ds.OutputList();
            Console.WriteLine($"\nTong gia khu dat: {ds.TinhTongGiaDat()}");
            Console.WriteLine($"Tong gia nha pho: {ds.TinhTongGiaNhaPho()}");
            Console.WriteLine($"Tong gia chung cu: {ds.TinhTongGiaChungCu()}");
            Console.WriteLine("\n---Xuat theo yeu cau---");
            Console.WriteLine("Danh sach cac khu dat co dien tich > 100m2 hoac la nha pho ma co dien tich >60m2 va nam xay dung >= 2019");
            ds.XuatTheoYeuCau();
            Console.WriteLine("\n---Tim kiem bat dong san---");
            Console.Write("Nhap dia diem can tim: ");
            string diadiem = Console.ReadLine() ?? "";
            long gia;
            double dientich;
            while (true)
            {
                Console.Write("Nhap gia can tim: ");
                string temp = Console.ReadLine();
                long temp1;
                if (long.TryParse(temp, out temp1) && temp1 >= 0)
                {
                    gia = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            while (true)
            {
                Console.Write("Nhap dien tich can tim: ");
                string temp = Console.ReadLine();
                double temp1;
                if (double.TryParse(temp, out temp1) && temp1 >= 0)
                {
                    dientich = temp1;
                    break;
                }
                Console.WriteLine("Error Valid Number.");
            }
            ds.TimKiem(diadiem, gia, dientich);
        }
    }
}
