using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    internal class FileData : IDataProvider
    {
        public string GetData()
        {
            return "Данные из файла";
        }
    }
}
