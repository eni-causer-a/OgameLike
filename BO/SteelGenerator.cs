using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class SteelGenerator : RessourceGenerator
    {
        public override List<Ressource> RessourceBySecond()
        {
            return new List<Ressource>() { new Ressource { name = PlanetType.STEEL, lastUpdate = DateTime.Now, lastQuantity = (3 * level) + 10 } };
        }

        public override List<Ressource> NextCost()
        {
            return new List<Ressource>
            {
                new Ressource { name = PlanetType.ENERGIE, lastUpdate = DateTime.Now, lastQuantity = level },
                new Ressource { name = PlanetType.OXYGENE, lastUpdate = DateTime.Now, lastQuantity = OxygeneQty(level) },
                new Ressource { name = PlanetType.STEEL, lastUpdate = DateTime.Now, lastQuantity =  AcierQty(level) },
                new Ressource { name = PlanetType.URANIUM, lastUpdate = DateTime.Now, lastQuantity = UraniumQty(level)}
            };
        }

        public override List<Ressource> TotalCost()
        {

            var energie = new Ressource { name = PlanetType.ENERGIE, lastUpdate = DateTime.Now, lastQuantity = 0 };
            var oxygene = new Ressource { name = PlanetType.OXYGENE, lastUpdate = DateTime.Now, lastQuantity = 0 };
            var acier = new Ressource { name = PlanetType.STEEL, lastUpdate = DateTime.Now, lastQuantity = 0 };
            var uranium = new Ressource { name = PlanetType.URANIUM, lastUpdate = DateTime.Now, lastQuantity = 0 };


            for (int i = 1; i <= level; i++)
            {
                energie.lastQuantity += energie.lastQuantity + i;
                oxygene.lastQuantity += energie.lastQuantity + OxygeneQty(i);
                acier.lastQuantity += energie.lastQuantity + AcierQty(i);
                uranium.lastQuantity += energie.lastQuantity + UraniumQty(i);
            }

            return new List<Ressource> { energie, oxygene, acier, uranium };


        }

        public int? OxygeneQty(int? lvl)
        {
            return lvl + (200 * (lvl / 10)) + 20;
        }

        public int? AcierQty(int? lvl)
        {
            return lvl + (100 * (lvl / 8)) + 20;
        }

        public int? UraniumQty(int? lvl)
        {
            return (int)Math.Pow((double)lvl, 3) + (200 * (lvl / 20)) + 20;
        }
    }
}
