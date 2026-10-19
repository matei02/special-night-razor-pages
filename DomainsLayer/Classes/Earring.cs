using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer
{
    public class Earring : Jewelry
    {
        public Earring(int id, Material material, int price, string name, int quantity) : base(id, material, price, name, quantity)
        { }

        public override string ToString()
        {
            return $"Earrrings: {quantity} pcs, {material}, €{price}";
        }
    
    }
}
