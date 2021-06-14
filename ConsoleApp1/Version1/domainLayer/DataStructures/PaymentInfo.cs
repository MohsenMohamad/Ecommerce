namespace Version1.domainLayer.DataStructures
{
    public class PaymentInfo
    {
        public string CardNumber;
        public int ExpMonth;
        public int ExpYear;
        public string CardHolder;
        public int CardCcv;
        public int HolderId;

        public PaymentInfo(string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId)
        {
            this.CardNumber = cardNumber;
            this.ExpMonth = expMonth;
            this.ExpYear = expYear;
            this.CardHolder = cardHolder;
            this.CardCcv = cardCcv;
            this.HolderId = holderId;
        }
    }
}