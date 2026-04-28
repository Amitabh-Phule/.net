namespace DIP
{

    // Abstraction
    interface IMessage
    {
        void Send();
    }

    // Low-level module
    class Email : IMessage
    {
        public void Send()
        {
            Console.WriteLine("Email Sent");
        }
    }

    class SMS : IMessage
    {
        public void Send()
        {
            Console.WriteLine("SMS Sent");
        }
    }

    // High-level module
    class Notification
    {
        private IMessage message;

        // Constructor injection
        public Notification(IMessage msg)
        {
            message = msg;
        }

        public void Notify()
        {
            message.Send();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessage msg = new Email();   // Can switch to SMS easily
            Notification notification = new Notification(msg);

            notification.Notify();
        }
    }
}
