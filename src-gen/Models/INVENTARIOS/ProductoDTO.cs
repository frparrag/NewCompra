using System.ComponentModel.DataAnnotations;

namespace Models.INVENTARIOS
{
    public class ProductoDTO
    {
public int Id { get; set; }

public string Nombre { get; set; }

public string Descripcion { get; set; }

public int Cantidad { get; set; }

public int Descuento { get; set; }

public int Valor { get; set; }

public string Codigo { get; set; }

public int TiendaId { get; set; }

	}
	
	public class ProductoGridDTO
    {
public int Id { get; set; }

public string Nombre { get; set; }

public string Descripcion { get; set; }

public int Cantidad { get; set; }

public int Descuento { get; set; }

public int Valor { get; set; }

public string Codigo { get; set; }

public string TiendaId { get; set; }

	}
}

