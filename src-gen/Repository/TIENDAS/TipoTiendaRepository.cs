using Dapper;
using Models.TIENDAS;
using SqlServerDB;
using System.Collections.Generic;
using System.Data;

namespace Repository.TIENDAS
{
    public interface ITipoTiendaRepository
    {
		IEnumerable<TipoTiendaDTO> ListarDropDown();	
    }
    
    public class TipoTiendaRepository : BaseRepository, ITipoTiendaRepository
    {
		#region INIT
		public TipoTiendaRepository(IDbConnector db) 
		{
			_db = db;
		}	
		#endregion
		
		#region CREATE
		#endregion
		
		#region READ
		public IEnumerable<TipoTiendaDTO> ListarDropDown() {           
			var list = _db.GetConnection()
						.Query<TipoTiendaDTO>(@"SELECT Id, 
														  Nombre 
												   FROM dbo.TipoTienda;");
			return list;
		}	
		
		#endregion
		
		#region UPDATE
		#endregion
		
		#region DELETE
		#endregion
    }
}

