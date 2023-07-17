namespace Banks
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Branch> Branches {get; }=new();
        public Customer(string name ,string address)
        {
            Name = name;
            Address = address;
        }
        public void Update(string name,string address)
        {
            Name = name;
            Address = address;
        }
    }
}