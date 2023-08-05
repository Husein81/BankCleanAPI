namespace Bank.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Branch> Branches { get; set; } =new();
        public Customer(string name ,string address,List<Branch> branches)
        {
            Name = name;
            Address = address;
            Branches = branches;
        }
        public void Update(int id,string name,string address,List<Branch> branches)
        {
            Id= id;
            Name = name;
            Address = address;
            Branches = branches;
        }
        public void UpdateDetails(string name,string address)
        {
            Name = name;
                Address = address;
        }
        public void UpdateBranch(List<Branch> br)
        {
            Branches.AddRange(br?.Where(newItem
                => !br.Contains(newItem)) ?? Enumerable.Empty<Branch>());
            Branches.RemoveAll(oldItem
                    => !br?.Contains(oldItem) ?? true);
        }
        public void AddBranch(Branch branch)
            => Branches.Add(branch);
        public void RemoveBranch(Branch branch)
            => Branches.Remove(branch);
    }
}