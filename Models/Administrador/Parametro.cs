namespace SICUENTANOS_Back.Models.Administrador;

public class Parametro 
{
    public Guid Id { get; set; }

    public String? VcNombre { get; set; }

    public String? VcCodigoInterno { get; set; }

    public Boolean BEstado { get; set; }

    public DateTime DtFechaCreacion { get; set; }

    public DateTime DtFechaActualizacion { get; set; }

    public virtual ICollection<ParametroDetalle>? ParametroDetalle {get;set;}
}