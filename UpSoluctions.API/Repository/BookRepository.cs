﻿using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(SystemContext context) : base(context)
        {
        }
    }
}
