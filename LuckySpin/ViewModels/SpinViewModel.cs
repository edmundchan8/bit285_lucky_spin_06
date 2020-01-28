using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckySpin.ViewModels
{
    public class SpinViewModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool Winner { get; set; }
        public string LuckyNumber { get; set; }
    }
}
