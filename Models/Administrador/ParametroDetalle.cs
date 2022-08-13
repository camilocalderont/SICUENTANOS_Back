namespace SICUENTANOS_Back.Models.Administrador;

public class ParametroDetalle 
{
    public Guid Id { get; set; }

    public Guid ParametroId { get; set; }
    public virtual Parametro? Parametro { get; set; }

    public String? VcNombre { get; set; }

    public String? TxDescripcion { get; set; }

    public String? VcCodigoInterno { get; set; }

    public Decimal DCodigoIterno { get; set; }

    public Boolean BEstado { get; set; }

    public int? RangoDesde { get; set; }

    public int? RangoHasta { get; set; }
}