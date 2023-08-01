using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Bank.Application.DTOs;
namespace Bank.Application.Commands.CustomerCommands
{
   public record UpdateCustomerCommand(int id ,string name,string address) : IRequest<CustomerDTO>
}
