using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Helpers
{
    internal static class RndValueHelpers
    {
        public static Random alea = new Random();

        // Valeur aléatoire entre 0 (inclus) et max (exclu)
        public static int Next(int max) => alea.Next(max);

        // Valeur aléatoire entre min (inclus) et max (exclu)
        public static int Next(int min, int max) => alea.Next(min, max);
    }
}