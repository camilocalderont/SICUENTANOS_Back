namespace SICUENTANOS_Back.Models.Administrador;

public class DiasFestivo 
{
    public Guid Id { get; set; }

    public DateTime DtFecha { get; set; }

    public String? VcDescripcion { get; set; }

    public DateTime DtFechaCreacion { get; set; }

    public DateTime DtFechaActualizacion { get; set; }

    public DateTime? DtFechaAnulacion { get; set; }
}