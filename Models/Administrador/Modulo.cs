namespace SICUENTANOS_Back.Models.Administrador
{
    public class Modulo
    {
        public int Id { get; set; }
        public string? VcNombre { get; set; }
        public string? VcDescricion { get; set; }
        public string? VcIcono { get; set; }
        public bool Iestado { get; set; }
        public List<Actividad>? Actividades { get; set; }
        public DateTime DtFechaCreacion { get; set; }    
        public DateTime DtFechaActualizacion { get; set; }    
        public DateTime DtFechaAnulacion { get; set; }          
    }
}