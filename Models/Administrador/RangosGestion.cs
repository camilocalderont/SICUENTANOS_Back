namespace SICUENTANOS_Back.Models.Administrador;

public class RangosGestion 
{
    public Guid Id { get; set; }

    public String? VcNombre { get; set; }

    public Double Porcentaje { get; set; }

    public String? VcColor { get; set; } 

    public Boolean BEstado { get; set; }

    public DateTime DtFechaCreacion { get; set; }

    public DateTime DtFechaActualizacion { get; set; }

    public DateTime? DtFechaEAnulacion { get; set; }
}