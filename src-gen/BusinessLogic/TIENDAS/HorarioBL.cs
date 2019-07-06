using Common.Utils;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
	public interface IHorarioBL
	{
		Result<IEnumerable<HorarioDTO>> ListarDropDown();	
	}
	
	public class HorarioBL : BaseBL, IHorarioBL
	{
		#region INIT
		private HorarioRepository _repository;
		
		public HorarioBL(IDbConnector db)
		{
			_db = db;
			_repository = new HorarioRepository(_db);
		}	
		#endregion
		
		#region CREATE
		#endregion
		
		#region READ
			public Result<IEnumerable<HorarioDTO>> ListarDropDown()
			{
			    // Inicializaciones
			    var result = new Result<IEnumerable<HorarioDTO>>();
			
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
