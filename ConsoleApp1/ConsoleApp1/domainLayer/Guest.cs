using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class Guest : Person
    {
        internal bool signin { get; private set; }

        public Guest()
        {
            shoppingCart = new ShoppingCart();
            signin = false;
        }

        public void Login() {
            signin = true;
        }

    }
}
