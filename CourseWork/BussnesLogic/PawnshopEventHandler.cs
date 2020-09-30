namespace CourseWork.BusinessLogic
{
    public delegate void PawnshopStateHandler(object sender, PawnshopEventArgs e);

    public class PawnshopEventArgs
    {
        public string Message { get; } // Message
        public Thing thing { get; } // Thing that bought or sold
        public Client client { get; } // Client that buy or sell

        public PawnshopEventArgs(string _message, Thing _thing, Client _client) // Ctor
        {
            Message = _message;
            thing = _thing;
            client = _client;
        }
    }
}
