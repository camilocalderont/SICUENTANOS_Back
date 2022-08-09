namespace SICUENTANOS_Back.Models.Administrador
{
    public class Rol
    {
        public int Id { get; set; }
        public string? VcNombre { get; set; }
        public bool Iestado { get; set; }        
        public DateTime DtFechaCreacion { get; set; }    
        public DateTime DtFechaActualizacion { get; set; }    
        public DateTime DtFechaAnulacion { get; set; }  
        public ICollection<Actividad>? Actividades { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}