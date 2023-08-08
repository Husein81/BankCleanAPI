namespace Bank.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Assets { get; set; }
        public List<Customer> Customers { get; } = new();
        public Branch(string name, string address, double assets)
        {
            Name = name;
            Address = address;
            Assets = assets;

        }
        public void Update(string name, string address, double assets)
        {
            Name = name;
            Address = address;
            Assets = assets;
        }
        public void UpdateCustomer(List<Customer> customers)
        {
            Customers.AddRange(customers?.Where(newItem => !customers.Contains(newItem)) ?? Enumerable.Empty<Customer>());
            Customers.RemoveAll(oldItem => !customers?.Contains(oldItem) ?? true);
        }
    }
}
