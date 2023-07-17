using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; } 
        public double Assets { get; set; }
        public List<Customer> Customers { get;} = new();
        public Branch(string name, string address,double assets)
        {
            Name = name;
            Address = address;  
            Assets = assets;
        }
        public void Update(string name,string address,double assets)
        {
            Name = name;
            Address = address;
            Assets = assets;
        }

    }
}
