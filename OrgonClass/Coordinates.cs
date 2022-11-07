using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgonClass
{
    public class Coordinates
    {

        //make a x y int variables privates
        private long x;
        private long y;
        //bassic constructor with both vars
        public Coordinates(long x, long y)
        {
            this.x = x;
            this.y = y;
        }
        //generate get ans setters
        public long X
        {
            get { return x; }
            set { x = value; }
        }

        public long Y
        {
            get { return y; }
            set { y = value; }
        }

    }
}
