using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class UraniumGenerator : RessourceGenerator
    {
        public override List<Ressource> RessourceBySecond()
        {
            return new List<Ressource>() { new Ressource { name = PlanetType.URANIUM, lastUpdate = DateTime.Now, lastQuantity = 7* (int)Math.Pow((double)level, 3) + 2 } };
        }

        public override List<Ressource> NextCost()
        {
            return new List<Ressource>
            {
                new Ressource { name = PlanetType.ENERGIE, lastUpdate = DateTime.Now, lastQuantity = level },
                new Ressource { name = PlanetType.OXYGENE, lastUpdate = DateTime.Now, lastQuantity = OxygeneQty(level) },
                new Ressource { name = PlanetType.STEEL, lastUpdate = DateTime.Now, lastQuantity =  AcierQty(level) }
            };
        }

        public override List<Ressource> TotalCost()
        {

            var energie = new Ressource { name = PlanetType.ENERGIE, lastUpdate = DateTime.Now, lastQuantity = 0 };
            var oxygene = new Ressource { name = PlanetType.OXYGENE, lastUpdate = DateTime.Now, lastQuantity = 0 };
            var acier = new Ressource { name = PlanetType.STEEL, lastUpdate = DateTime.Now, lastQuantity = 0 };


            for (int i = 1; i <= level; i++)
            {
                energie.lastQuantity += energie.lastQuantity + i;
                oxygene.lastQuantity += energie.lastQuantity + OxygeneQty(i);
                acier.lastQuantity += energie.lastQuantity + AcierQty(i);
            }

            return new List<Ressource> { energie, oxygene, acier };


        }

        public int? OxygeneQty(int? lvl)
        {
            return (200 * (lvl / 2)) + 20;
        }

        public int? AcierQty(int? lvl)
        {
            return (100*(lvl/3)) + 20;
        }

    }
}
