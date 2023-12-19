using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igrok_final_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Igra> igroki = new List<Igra>();
            List<Igra> dead_igrok = new List<Igra>();
            List<Igra> Vragi = new List<Igra>();
            List<Igra> Friend = new List<Igra>();
            Igra play = new Igra();
            play.Plays(igroki, dead_igrok, play, Vragi, Friend);
        }
    }
}
