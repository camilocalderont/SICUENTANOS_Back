namespace SICUENTANOS_Back.Models.Administrador
{
    public class Usuario
    {
        public int Id { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string? VcDocumento { get; set; }
        public string? VcPrimerNombre { get; set; }
        public string? VcSegundoNombre { get; set; }
        public string? VcPrimerApellido { get; set; }
        public string? VcSegundoApellido { get; set; }
        public string? VcCorreo { get; set; }
        public string? VcTelefono { get; set; }
        public string? VcDireccion { get; set; }
        public string? VcIdAzure { get; set; }
        public string? VcToken { get; set; }
        public bool Iestado { get; set; }        
        public DateTime DtFechaCreacion { get; set; }    
        public DateTime DtFechaActualizacion { get; set; }    
        public DateTime DtFechaAnulacion { get; set; } 
        public ICollection<Rol>? Roles { get; set; }  
    }
}