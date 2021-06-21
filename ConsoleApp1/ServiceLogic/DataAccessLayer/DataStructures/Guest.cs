using System.Threading;

namespace ServiceLogic.DataAccessLayer.DataStructures
{
    public class Guest : Person
    {

        private static long _idCounter;

        private long guestId { get; }

        public Guest()
        {
            guestId = Interlocked.Increment(ref _idCounter);
            shoppingCart = new ShoppingCart();
            
        }

        public long GetId()
        {
            return guestId;
        }
        
    }
}
