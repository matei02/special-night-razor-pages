using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer.Classes
{
    public class Necklace : Jewelry
    {
        public Necklace(int id, Material material, int price, string name, int quantity) : base(id, material, price, name, quantity)
        { }

        public override string ToString()
        {
            return $"Necklace: {quantity} pcs, {material}, € {price}";
        }
    }
}
