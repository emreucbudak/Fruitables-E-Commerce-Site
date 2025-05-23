﻿using Entities.Exceptions;
using Entities.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OwnProductsManager : IOwnProductsService
    {
        private readonly IRepositoryManager _rp;

        public OwnProductsManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddOwnProductsFromService(OwnProduct ownProduct)
        {
            await _rp.ownProducts.AddOwnProduct(ownProduct);
            _rp.Save();
        }

        public async Task<IEnumerable<OwnProduct>> GetAllOwnProducts(bool v)
        {
            return await _rp.ownProducts.GetAllOwnProducts(v);
        }

        public async Task<OwnProduct> GetOwnProductById(int id)
        {
            var x =  await _rp.ownProducts.GetOwnProductById(id,false);
            if (x == null)
            {
                throw new OwnProductNotFoundExceptions(id);
            }
            return x;
        }

        public async Task RemoveOwnProductsFromService(int ownProduct)
        {
            var x = await GetOwnProductById(ownProduct);

            await _rp.ownProducts.RemoveOwnProduct(x);
            _rp.Save();
        }

        public async Task UpdateOwnProductsFromService(int id , OwnProduct ownProduct)
        {
            var x = await GetOwnProductById(id);

            x.Description = ownProduct.Description;
            x.Name = ownProduct.Name;
            x.ImgUrl = ownProduct.ImgUrl;
            x.CategoryID = ownProduct.CategoryID;
            await _rp.ownProducts.UpdateOwnProduct(x);
            _rp.Save();
        }
    }
}
