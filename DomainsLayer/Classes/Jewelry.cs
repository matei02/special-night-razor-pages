using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer
{
    public enum Material
    {
        GOLD,
        SILVER
    }


    public abstract class Jewelry : Product
    {
        protected Material material;

        public Material Material
        {
            get => default;
            set
            {
            }
        }

        protected Jewelry(int id, Material material, int price, string name, int quantity) : base(id, name, quantity, price)
        {
            this.material = material;
            this.price = price;
        }

        public override string ToString()
        {
            return $"Jewelry: {material}, {price}";
        }

        public Material GetMaterial()
        {
            return this.material;
        }
    }
}
