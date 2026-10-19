using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DomainsLayer
{
    public enum DressColors 
    {
        RED, //0
        BLUE,//1
        BLACK//2
    }

    public class Dress : Product
    {
        private int sizeB, sizeW, sizeH;
        private DressColors color;

        public Dress(int id, DressColors color, int sizeB1, int sizeW1, int sizeH1, string name, int quantity, int price) : base(id, name, quantity, price)
        {
            this.color = color;
            this.sizeB = sizeB1;
            this.sizeW = sizeW1;
            this.sizeH = sizeH1;
        }

        public DressColors DressColors
        {
            get => default;
            set
            {
            }
        }

        public int GetSizeB()
        {
            return sizeB;
        }

        public int GetSizeW()
        {
            return sizeW;
        }

        public int GetSizeH()
        {
            return sizeH;
        }

        public DressColors GetColor()
        {
            return this.color;
        }

        public override string ToString()
        {
            return $"{this.color} dress, sizes B/W/H = {sizeB}/{sizeW}/{sizeH},\n " +
                $"Quantity: {quantity} pieces, \n" +
                $"Price: €{price}";
        }
    }
}
