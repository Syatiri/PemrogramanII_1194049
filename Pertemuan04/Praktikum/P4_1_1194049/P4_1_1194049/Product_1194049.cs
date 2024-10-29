using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_1194049
{
    public abstract class Product_1194049
    {
        private string myType;
        private string myTitle;
        
        public Product_1194049()
        {

        }

        public Product_1194049(string type, string title)
        {
            myType = type;
            myTitle = title;
        }

        public string MyType
        {
            get { return myType; }
            set { myType = value; }
        }

        public string MyTitle
        {
            get { return myTitle; }
            set { myTitle = value; }
        }

        public abstract void DisplayInfo();
    }
}
