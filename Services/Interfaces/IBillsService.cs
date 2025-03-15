using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBillsService
    {
        Task AddBillsFromService(Bills bil);
        Task <Bills>RemoveBillsFromService(int billsId);
        Task <Bills>UpdateBillsFromService(Bills bills);
        Task<IEnumerable<Bills>> GetAllBillsFromService(bool v);
        Task<Bills> GetBillsFromService(int billsId);

    }
}
