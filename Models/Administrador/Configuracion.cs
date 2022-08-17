namespace SICUENTANOS_Back.Models.Administrador;

public class Configuracion 
{
    //internal int Id;

    public Guid Id { get; set; }
    public int? IDiasLimiteRespuesta { get; set; }
    public Boolean BSabadoLaboral { get; set; }
    public Boolean BDomingoLaboral { get; set; }
    public Boolean BEstado { get; set; }
    public DateTime DtFechaCreacion { get; set; }
    public DateTime DtFechaActualizacion { get; set; }
    public DateTime? DtFechaAnulacion { get; set; }

}