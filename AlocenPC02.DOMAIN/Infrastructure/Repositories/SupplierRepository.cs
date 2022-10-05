using AlocenPC02.DOMAIN.Core.Entities;
using AlocenPC02.DOMAIN.Core.Interfaces;
using AlocenPC02.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlocenPC02.DOMAIN.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SalesContext _context;
        public SupplierRepository(SalesContext context)
        {
            _context = context;

        }
        //devolver listado de suppliers
        public async Task<IEnumerable<Supplier>> GetSuppliers() //devuelve lista de objetos
        {
            var suppliers = await _context.Supplier.ToListAsync();
            return suppliers;

        }
        public async Task<Supplier> GetSupplier(int id)
        {
            return await _context.Supplier.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Supplier supplier)
        {
            await _context.Supplier.AddAsync(supplier);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Supplier supplier)
        {
            _context.Supplier.Update(supplier);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }


        public async Task<bool> Delete(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
                return false;

            _context.Supplier.Remove(supplier);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }



    }
}
