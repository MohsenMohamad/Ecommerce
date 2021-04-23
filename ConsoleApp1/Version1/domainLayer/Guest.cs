namespace Version1.domainLayer
{
    public sealed class Guest : Person
    {
        public static Guest Instance { get; } = new Guest();
        internal bool signin { get; private set; }

        static Guest()
        {
        }

        private Guest()
        {
            shoppingCart = new ShoppingCart();
            signin = false;
        }

        public void Login() {
            signin = true;
        }

        public void Logout()
        {
            shoppingCart = new ShoppingCart();
            signin = false;
        }
    }
}
