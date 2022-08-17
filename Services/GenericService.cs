using SICUENTANOS_Back.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICUENTANOS_Back.Service
{
    public interface IGenericService : IDisposable
    {
        ApplicationDbContext Context { get; }
        
    }

    public class GenericService : IGenericService
    {
        public ApplicationDbContext Context { get; }

        public GenericService (ApplicationDbContext context)
        {
            Context = context;
        }

        public void Get()
        {
            Context.SaveChanges();
        }

        public void Get(Guid id)
        {
            Context.Dispose();
        }

         public void Put(Guid id)
        {
            Context.Dispose();
        }

         public void Post(Guid id)
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}