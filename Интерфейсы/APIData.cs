using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Интерфейсы
{
    internal class APIData : IDataProvider
    {
        public string GetData()
        {
            return "Данные API";
        }
    }
}
