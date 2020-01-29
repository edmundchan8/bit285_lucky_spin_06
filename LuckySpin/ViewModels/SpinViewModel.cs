using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckySpin.Models;

namespace LuckySpin.ViewModels
{
    public class SpinViewModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool Winner { get; set; }
        public int Luck { get; set; }
        public string ImgDisplay { get; set; }
        public string FirstName { get; set; }
    }


}
