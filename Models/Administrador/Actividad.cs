namespace SICUENTANOS_Back.Models.Administrador
{
    public class Actividad
    {
        public int Id { get; set; }
        public int ModuloId { get; set; } 
        public Modulo? Modulo { get; set;}
        public string? VcNombre { get; set; }
        public int IdPadre { get; set; }
        public string? VcDescricion { get; set; }
        public string? VcRedireccion { get; set; }
        public string? VcIcono { get; set; }
        public bool Iestado { get; set; }     
        public DateTime DtFechaCreacion { get; set; }    
        public DateTime DtFechaActualizacion { get; set; }    
        public DateTime DtFechaAnulacion { get; set; }     
        public ICollection<Rol>? Roles { get; set; }        
    }
}