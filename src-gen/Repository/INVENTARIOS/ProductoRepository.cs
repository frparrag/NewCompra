using Dapper;
using Models.INVENTARIOS;
using SqlServerDB;
using System.Collections.Generic;
using System.Data;

namespace Repository.INVENTARIOS
{
    public interface IProductoRepository
    {
		int Registrar(ProductoDTO productoDTO, IDbTransaction atom);	
		IEnumerable<ProductoGridDTO> ListarGrid();	
		ProductoDTO Obtener(int id);	
		void Editar(ProductoDTO productoDTO, IDbTransaction atom);	
    }
    
    public class ProductoRepository : BaseRepository, IProductoRepository
    {
		#region INIT
		public ProductoRepository(IDbConnector db) 
		{
			_db = db;
		}	
		#endregion
		
		#region CREATE
		public int Registrar(ProductoDTO productoDTO, IDbTransaction atom = null) {           
			int id = _db.GetConnection()
						.QuerySingle<int>(@"INSERT INTO dbo.Producto 
						(
						Nombre,Descripcion,Cantidad,Descuento,Valor,Codigo,TiendaId
						) 
						OUTPUT Inserted.ID
						VALUES 
						(
						@Nombre,@Descripcion,@Cantidad,@Descuento,@Valor,@Codigo,@TiendaId
						);", 
						productoDTO, 
						atom);
			return id;
		}	
		
		#endregion
		
		#region READ
		public IEnumerable<ProductoGridDTO> ListarGrid() {           
			var list = _db.GetConnection()
						.Query<ProductoGridDTO>(@"SELECT 
							producto.Id
							,producto.Nombre
							,producto.Descripcion
							,producto.Cantidad
							,producto.Descuento
							,producto.Valor
							,producto.Codigo
							,tienda.Nombre as TiendaId
						FROM dbo.Producto producto
							INNER JOIN dbo.Tienda tienda ON (producto.TiendaId = tienda.Id) 
							; 
						");
			return list;
		}
			
		public ProductoDTO Obtener(int id) {           
			var productoDTO = _db.GetConnection()
						.QuerySingle<ProductoDTO>(@"SELECT 
												Id,Nombre,Descripcion,Cantidad,Descuento,Valor,Codigo,TiendaId
										    FROM dbo.Producto
										    WHERE Id = @Id;", new { Id = id });
			return productoDTO;
		}	
		
		#endregion
		
		#region UPDATE
		public void Editar(ProductoDTO productoDTO, IDbTransaction atom = null) {           
			_db.GetConnection()
			    .Execute(@"UPDATE dbo.Producto
			                SET Nombre= @Nombre,Descripcion= @Descripcion,Cantidad= @Cantidad,Descuento= @Descuento,Valor= @Valor,Codigo= @Codigo,TiendaId= @TiendaId
			                WHERE Id = @Id;", productoDTO, atom);
		}
			
		#endregion
		
		#region DELETE
		#endregion
    }
}

