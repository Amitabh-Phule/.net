namespace OCP
{

    // Common interface
    interface IPayment
    {
        void Pay();
    }

    // Different implementations
    class CreditCardPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using Credit Card");
        }
    }

    class UPIPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using UPI");
        }
    }
    //If we want to add CashPayment, we just create it

    //No changes to existing code
    // Just extend by adding new class
    class CashPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Paid using Cash");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IPayment payment;

            payment = new CreditCardPayment();
            payment.Pay();

            payment = new UPIPayment();
            payment.Pay();

            payment = new CashPayment();
            payment.Pay();
        }
    }
}
