using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1
{

    class Computer
    {
        // кодом
        public long id;
        // названием  марки компьютера
        public string Model;
        // типом  процессора,
        public string CpuType;
        //частотой  работы  процессора
        public float CpuSpeed;
        //объемом оперативной памяти
        public int RamSize;
        //объемом жесткого диска
        public int HddVolume;
        //объемом памяти видеокарты
        public int VRamSize;
        // стоимостью компьютера 
        public double Price;
        //количеством экземпляров, имеющихся в наличии.
        public uint QtyInStock;
    }

    class Program
    {
        static void Main(string[] args)
        {            
            List<Computer> l = new List<Computer>()
            {
                new Computer(){ CpuSpeed=2.3F, CpuType="Intel Core 2 Duo", HddVolume=60, id=1 , Model="OldPc", Price=32000, QtyInStock=73, RamSize=2, VRamSize=1 },
                new Computer(){ CpuSpeed=1.8F, CpuType="Intel Core i3", HddVolume=60, id=2 , Model="OfficePc i3 Low", Price=60000, QtyInStock=18, RamSize=4, VRamSize=1 },
                new Computer(){ CpuSpeed=2.3F, CpuType="Intel Core i3", HddVolume=80, id=3 , Model="OfficePc i3 Mid", Price=76000, QtyInStock=4, RamSize=4, VRamSize=2 },
                new Computer(){ CpuSpeed=2.3F, CpuType="Intel Core i5", HddVolume=120, id=4 , Model="OfficePc i5 Low", Price=90000, QtyInStock=12, RamSize=8, VRamSize=2 },
                new Computer(){ CpuSpeed=2.5F, CpuType="Intel Core i5", HddVolume=320, id=5 , Model="OfficePc i5 Mid Mk1", Price=100000, QtyInStock=15, RamSize=8, VRamSize=4 },
                new Computer(){ CpuSpeed=3.3F, CpuType="Intel Core i5", HddVolume=500, id=6 , Model="OfficePc i5 Mid Mk2", Price=120000, QtyInStock=31, RamSize=16, VRamSize=8 },
                new Computer(){ CpuSpeed=3.5F, CpuType="Intel Core i5", HddVolume=500, id=7 , Model="OfficePc i5 High", Price=150000, QtyInStock=231, RamSize=16, VRamSize=1 },
                new Computer(){ CpuSpeed=0.066F, CpuType="Intel 386DX", HddVolume=1, id=8 , Model="Ancient", Price=1200, QtyInStock=1, RamSize=1, VRamSize=0 },
                new Computer(){ CpuSpeed=2.3F, CpuType="Intel i7", HddVolume=160, id=9 , Model="HighPc", Price=250000, QtyInStock=13, RamSize=16, VRamSize=8 },
                new Computer(){ CpuSpeed=4.5F, CpuType="AMD Ryzen Threadripper 2990WX", HddVolume=1000, id=10 , Model="SuperComp", Price=650000, QtyInStock=1, RamSize=128, VRamSize=16 },
            };
                        
            Console.Write($"C каким процесором ищем компы?\n ({String.Join(",", l.Select(x => x.CpuType).ToList())})\n:");
            string SearchStr = Console.ReadLine();
            Console.WriteLine($"Найдены модели: {String.Join(", ", l.Where(x => x.CpuType == SearchStr).Select(x => x.Model).ToList())}");
                        
            Console.Write("Введите минимальное количество ОЗУ для поиска:");
            SearchStr = Console.ReadLine();
            Console.WriteLine($"Найдены модели: {String.Join(",", l.Where(x => x.RamSize > int.Parse(SearchStr)).Select(x => x.Model).ToList())}");
            Console.WriteLine();
                        
            Console.WriteLine("Cписок, отсортированный по увеличению стоимости:");
            Console.WriteLine(String.Join(",\n", l.OrderBy(x => x.Price).Select(x => string.Format("{0} {1}", x.Model, x.Price)).ToList()));
            Console.WriteLine();
                        
            Console.WriteLine("Cписок, сгруппированный по типу процессора:");
            Console.WriteLine(String.Join(",\n", l.GroupBy(x => x.CpuType).Select(x => string.Format("{0} {1}", x.Key, x.Count())).ToList()));
            Console.WriteLine();
                        
            Console.WriteLine("Cамый дорогой: " + l.Aggregate((i, j) => i.Price > j.Price ? i : j).Model);
            Console.WriteLine("Cамый бюджетный: " + l.Aggregate((i, j) => i.Price < j.Price ? i : j).Model);
                        
            Console.WriteLine("Kоличестве не менее 30 штук: " + l.First(x => x.QtyInStock > 30).Model);

            Console.ReadKey();

        }
    }
}
