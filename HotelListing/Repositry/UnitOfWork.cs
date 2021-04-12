using HotelListing.IRepositoty;
using HotelListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repositry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

        //garbage collector is just seeing when i'm done or when the operations please free up the memory
        public void Dispose()
        {
            // dispose of context - meaning kill any memory that the connection to the database was using  the connection
            _context.Dispose();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
