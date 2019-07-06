using Dapper;
using Models.TIENDAS;
using SqlServerDB;
using System.Collections.Generic;
using System.Data;

namespace Repository.TIENDAS
{
    public interface ITiendaRepository
    {
		int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom);	
		IEnumerable<TiendaGridDTO> ListarGrid();	
		IEnumerable<TiendaDTO> ListarDropDown();	
		TiendaDTO Obtener(int id);	
		void Editar(TiendaDTO tiendaDTO, IDbTransaction atom);	
		void Eliminar(int id, IDbTransaction atom);	
    }
    
    public class TiendaRepository : BaseRepository, ITiendaRepository
    {
		#region INIT
		public TiendaRepository(IDbConnector db) 
		{
			_db = db;
		}	
		#endregion
		
		#region CREATE
		public int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom = null) {           
			int id = _db.GetConnection()
						.QuerySingle<int>(@"INSERT INTO dbo.Tienda 
						(
						Nombre,TipoId,HoraAperturaId,HoraCierreId
						) 
						OUTPUT Inserted.ID
						VALUES 
						(
						@Nombre,@TipoId,@HoraAperturaId,@HoraCierreId
						);", 
						tiendaDTO, 
						atom);
			return id;
		}	
		
		#endregion
		
		#region READ
		public IEnumerable<TiendaGridDTO> ListarGrid() {           
			var list = _db.GetConnection()
						.Query<TiendaGridDTO>(@"SELECT 
							tienda.Id
							,tienda.Nombre
							,tipoTienda.Nombre as TipoId
							,horario.Nombre as HoraAperturaId
							,horario.Nombre as HoraCierreId
						FROM dbo.Tienda tienda
							INNER JOIN dbo.TipoTienda tipoTienda ON (tienda.TipoId = tipoTienda.Id) 
							INNER JOIN dbo.Horario horario ON (tienda.HoraAperturaId = horario.Id) 
							INNER JOIN dbo.Horario horario ON (tienda.HoraCierreId = horario.Id) 
							; 
						");
			return list;
		}
			
		public IEnumerable<TiendaDTO> ListarDropDown() {           
			var list = _db.GetConnection()
						.Query<TiendaDTO>(@"SELECT Id, 
														  Nombre 
												   FROM dbo.Tienda;");
			return list;
		}	
		
		public TiendaDTO Obtener(int id) {           
			var tiendaDTO = _db.GetConnection()
						.QuerySingle<TiendaDTO>(@"SELECT 
												Id,Nombre,TipoId,HoraAperturaId,HoraCierreId
										    FROM dbo.Tienda
										    WHERE Id = @Id;", new { Id = id });
			return tiendaDTO;
		}	
		
		#endregion
		
		#region UPDATE
		public void Editar(TiendaDTO tiendaDTO, IDbTransaction atom = null) {           
			_db.GetConnection()
			    .Execute(@"UPDATE dbo.Tienda
			                SET Nombre= @Nombre,TipoId= @TipoId,HoraAperturaId= @HoraAperturaId,HoraCierreId= @HoraCierreId
			                WHERE Id = @Id;", tiendaDTO, atom);
		}
			
		#endregion
		
		#region DELETE
		public void Eliminar(int id, IDbTransaction atom = null) {           
			_db.GetConnection()
				.Execute(@"DELETE FROM dbo.Tienda 
						   WHERE Id = @Id;", new { Id = id }, atom);
		}	
		
		#endregion
    }
}

