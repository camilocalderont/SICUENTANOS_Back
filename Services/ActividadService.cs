using SICUENTANOS_Back.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using SICUENTANOS_Back.Models.Administrador;

namespace SICUENTANOS_Back.Services
{
    public class ActividadService : IGenericService
    {
        public IGenericRepository<Actividad> _genericRepository { get; }

        public ActividadService(IGenericRepository<Actividad> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Actividad>> GetAsync()
        {
            return _genericRepository.GetAsync();
        }

        public void CreateAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}