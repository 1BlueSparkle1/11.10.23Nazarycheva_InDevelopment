using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataHadler dataHadler = new ConsoleDataHadler();
            dataHadler.HadlerData(new APIData());
            dataHadler.HadlerData(new FileData());
        }
    }
}
