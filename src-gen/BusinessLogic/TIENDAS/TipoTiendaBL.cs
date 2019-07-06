using Common.Utils;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
	public interface ITipoTiendaBL
	{
		Result<IEnumerable<TipoTiendaDTO>> ListarDropDown();	
	}
	
	public class TipoTiendaBL : BaseBL, ITipoTiendaBL
	{
		#region INIT
		private TipoTiendaRepository _repository;
		
		public TipoTiendaBL(IDbConnector db)
		{
			_db = db;
			_repository = new TipoTiendaRepository(_db);
		}	
		#endregion
		
		#region CREATE
		#endregion
		
		#region READ
			public Result<IEnumerable<TipoTiendaDTO>> ListarDropDown()
			{
			    // Inicializaciones
			    var result = new Result<IEnumerable<TipoTiendaDTO>>();
			
			    // Acceso al repositorio
			    try
			    {
			        result.Data = _repository.ListarDropDown();
			    }
			    catch (Exception e)
			    {
			        result.Exception = e;
			        result.Message = e.Message;
			        return result;
			    }
			
			    // Salida satisfcatoria
			    result.Success = true;
			    result.Message = "Transacción realizada satisfactoriamente.";
			    return result;
			}	
			
		#endregion
		
		#region UPDATE
		#endregion
		
		#region DELETE
		#endregion
		
	}
}
