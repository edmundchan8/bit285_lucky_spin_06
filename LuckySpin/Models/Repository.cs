using System.Collections.Generic;
using LuckySpin.ViewModels;

namespace LuckySpin.Models
{
    public class Repository
    {
        private List<SpinViewModel> spins = new List<SpinViewModel>();
        public Player _player = new Player();

       //Property
       public IEnumerable<SpinViewModel> PlayerSpins {

            get { return spins; }
       }

        //Access method
        public void AddSpin(SpinViewModel s)
        {
            spins.Add(s);
        }

        //Adding a method to reset the spins
        public void ResetSpin()
        {
            spins.Clear();
        }
    }
}
