using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFaturas
{
    public class Orders
    {
        public int productId { get; set; }
        public string product { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
    }
}
