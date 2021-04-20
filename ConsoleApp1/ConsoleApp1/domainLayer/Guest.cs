namespace ConsoleApp1.domainLayer
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
