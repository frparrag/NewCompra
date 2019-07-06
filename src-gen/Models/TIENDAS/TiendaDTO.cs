using System.ComponentModel.DataAnnotations;

namespace Models.TIENDAS
{
    public class TiendaDTO
    {
public int Id { get; set; }

public string Nombre { get; set; }

[Required]
[Display(Name ="Tipo de tienda")]
public int TipoId { get; set; }

[Required]
[Display(Name ="Hora de apertura")]
public int HoraAperturaId { get; set; }

[Required]
[Display(Name ="Hora de cierre")]
public int HoraCierreId { get; set; }

	}
	
	public class TiendaGridDTO
    {
public int Id { get; set; }

public string Nombre { get; set; }

[Display(Name ="Tipo de tienda")]
public string TipoId { get; set; }

[Display(Name ="Hora de apertura")]
public string HoraAperturaId { get; set; }

[Display(Name ="Hora de cierre")]
public string HoraCierreId { get; set; }

	}
}

