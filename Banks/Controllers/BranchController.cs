using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Banks.Controllers
{
    public class BranchController : Controller
    {
        private readonly CustomerDbContext _context;
        public BranchController(CustomerDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<Branch> AddBranch(string name,string address,double assets)
        {
            var newbranch = await _context.Branch.AddAsync(new Branch(name, address, assets));
            await _context.SaveChangesAsync();
            return newbranch.Entity;
        }
        [HttpPut]
        public async Task<Branch> UpdateBranch(int id,string name ,string address,double assets)
        {
            var branch = await _context.Branch.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Not Found");
            branch.Update(name,address,assets);
            _context.Update(branch);
            await _context.SaveChangesAsync();
            return branch;
        }
        [HttpGet]
        public async Task<List<Customer>> GetBranchAsync()
        {
            return await _context.Customer.ToListAsync();
        }
        [HttpGet("GetBranchById")]
        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await _context.Branch.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpDelete]
        public async Task DeleteBranch(int id)
        {
            var branch=await _context.Branch.Include(branch=> branch.Id == id).FirstOrDefaultAsync(x=>x.Id==id)
                ??throw new Exception("Not Found");
            _context.Remove(branch);
            await _context.SaveChangesAsync();
        }
    }
}
