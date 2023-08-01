using Bank.Shared;

namespace Bank.Infrastructure.Data.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
    }
}