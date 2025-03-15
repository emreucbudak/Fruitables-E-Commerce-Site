using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IBillsRepositories _billsRepositories;

        public RepositoryManager(ApplicationDbContext context, IBillsRepositories billsRepositories)
        {
            _context = context;
            _billsRepositories = billsRepositories;
        }

        public IBillsRepositories IBillsRepositories => _billsRepositories;
    }
}
