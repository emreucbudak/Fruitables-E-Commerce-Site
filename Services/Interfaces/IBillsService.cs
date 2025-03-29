using Entities.DTO;
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
        Task AddBillsFromService(BillsDtoForInsert bil);
        Task <Bills>RemoveBillsFromService(int billsId);
        Task <Bills>UpdateBillsFromService(int id , BillsDtoForUpdate bills);
        Task<IEnumerable<BillsDtoForList>> GetAllBillsFromService(bool v);
        Task<BillsDtoForList> GetBillsFromService(int billsId);

    }
}
