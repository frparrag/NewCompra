using Dapper;
using Models.TIENDAS;
using SqlServerDB;
using System.Collections.Generic;
using System.Data;

namespace Repository.TIENDAS
{
    public interface IHorarioRepository
    {
		IEnumerable<HorarioDTO> ListarDropDown();	
    }
    
    public class HorarioRepository : BaseRepository, IHorarioRepository
    {
		#region INIT
		public HorarioRepository(IDbConnector db) 
		{
			_db = db;
		}	
		#endregion
		
		#region CREATE
		#endregion
		
		#region READ
		public IEnumerable<HorarioDTO> ListarDropDown() {           
			var list = _db.GetConnection()
						.Query<HorarioDTO>(@"SELECT Id, 
														  Nombre 
												   FROM dbo.Horario;");
			return list;
		}	
		
		#endregion
		
		#region UPDATE
		#endregion
		
		#region DELETE
		#endregion
    }
}

