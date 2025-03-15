using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBillsRepositories
    {
        Task AddBills(Bills bil);
        Task DeleteBills(Bills bil);
        Task UpdateBills(Bills bil);
        Task<Bills> GetBillsByID(int id,bool v);
        Task<IEnumerable<Bills>> GetAllBills(bool v);
    }
}
