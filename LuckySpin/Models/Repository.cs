using System.Collections.Generic;

namespace LuckySpin.Models
{
    public class Repository
    {
        private List<Spin> spins = new List<Spin>();
        public Player _player = new Player();

       //Property
       public IEnumerable<Spin> PlayerSpins {

            get { return spins; }
       }

        //Access method
        public void AddSpin(Spin s)
        {
            spins.Add(s);
        }
    }
}
