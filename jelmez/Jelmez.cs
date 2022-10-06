using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jelmez
{
    internal class Jelmez
    {
        private String costumeName;
        private int costumePrice;
        private DateTime costumeLimit;
        private bool kiberelt;

        public Jelmez(string costumeName, int costumePrice, DateTime costumeLimit, bool kiberelt)
        {
            this.CostumeName = costumeName;
            this.CostumePrice = costumePrice;
            this.CostumeLimit = costumeLimit;
            this.Kiberelt = kiberelt;
        }

        public string CostumeName { get => costumeName; set => costumeName = value; }
        public int CostumePrice { get => costumePrice; set => costumePrice = value; }
        public DateTime CostumeLimit { get => costumeLimit; set => costumeLimit = value; }
        public bool Kiberelt { get => kiberelt; set => kiberelt = value; }
    }
}
