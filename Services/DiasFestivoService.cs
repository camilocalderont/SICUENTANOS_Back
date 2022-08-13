
using SICUENTANOS_Back.Models;
using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models.Administrador;

namespace SICUENTANOS_Back.Services
{
    public class DiasFestivoService
    {
        private readonly ApplicationDbContext _context;

        public DiasFestivoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiasFestivo>> GetDiasFestivo()
        {
            return await _context.DiasFestivo.ToListAsync();            
        }
        
        public async Task<DiasFestivo> GetDiasFestivo(Guid id)
        {
            return await _context.DiasFestivo.FindAsync(id);
        } 

        public async Task<DiasFestivo> PutDiasFestivo(Guid id, DiasFestivo diasFestivo)      
        {
            _context.Entry(diasFestivo).State = EntityState.Modified;
            var registrosActualizados = await _context.SaveChangesAsync();
            if(registrosActualizados>0){
                return diasFestivo;
            }else{
                return null;
            }
        } 
    }
}