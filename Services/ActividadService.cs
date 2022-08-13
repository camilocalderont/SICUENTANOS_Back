
using SICUENTANOS_Back.Models;
using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models.Administrador;

namespace SICUENTANOS_Back.Services
{
    public class ActividadService
    {
        private readonly ApplicationDbContext _context;

        public ActividadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actividad>> GetActividad()
        {
            /*if (_context.Actividad == null)
            {
                return _context.Actividad;
            }*/
            return await _context.Actividad.ToListAsync();            
        }
    }
}