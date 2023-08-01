using Microsoft.AspNetCore.Mvc;
using MediatR;
using Bank.Domain;
using Bank.Application.DTOs;
using Bank.Application.Commands;


namespace Banks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Customer> AddCustomerAsync(string name,string address)
        {
            var newcustomer = await _context.Customer.AddAsync(new Customer(name, address));
            await _context.SaveChangesAsync();
            return newcustomer.Entity;

        }
        [HttpPut]
        public async Task<Customer> UpdateCustomer(int id,string name,string address)
        {
            var cust = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id)
                ??throw new Exception("Not Found");

            cust.Update(name, address);
            _context.Update(cust);
            await _context.SaveChangesAsync();
            return cust;
        }
        [HttpDelete]
        public async Task DeleteCustomerAsync(int id)
        {
            var cust = await _context.Customer.FirstOrDefaultAsync(x =>x.Id == id)
                ?? throw new Exception("Not Found");
            _context.Remove(cust);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        [HttpGet("GetCustomerId")]
        public async Task<Customer> GetCustomerByIDAsync(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
 