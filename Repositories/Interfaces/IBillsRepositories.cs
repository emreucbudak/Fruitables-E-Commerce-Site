using Entities.DTO;
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
        Task<BillsDtoForList> GetBillsByID(int id,bool v);
        Task<IEnumerable<BillsDtoForList>> GetAllBills(bool v);
        Task<Bills> GetBillsAndCheck(int id , bool v);
    }
}
