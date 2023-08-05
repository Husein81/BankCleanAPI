namespace Bank.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
    }
}