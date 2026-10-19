using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsLayer
{
    public enum ProductType
    {
        DRESS,
        SUIT,
        NECKLACE,
        BRACELET,
        EARRING
    }

    public abstract class Product
    {
        protected string name;
        protected int quantity;
        protected int price;
        protected int id;

        protected Product(int id, string name, int quantity, int price)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        public string GetInfo()
        {
            if (quantity > 1)
            {
                return $"{name.ToLower()}: {quantity} pieces, {price} euros";
            }
            else
            {
                return $"{name.ToLower()}: {quantity} piece, {price} euros";
            }
        }

        public int GetPrice()
        {
            return price; 
        }

        public void SetPrice(int price)
        {
            this.price=price;
        }

        public int GetID()
        {
            return id;
        }

        public string GetName()
        {
            return this.name;
        }

        public int Quantity { get { return quantity; } set { quantity = value; } }

        public override string ToString()
        {
            return $"{name}: {quantity} pieces, €{price}";
        }
    }
}
