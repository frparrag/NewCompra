using Common.Utils;
using Models.INVENTARIOS;
using Repository.INVENTARIOS;
using SqlServerDB;
using System;
using System.Collections.Generic;

namespace BusinessLogic.INVENTARIOS
{
	public interface IProductoBL
	{
		Result<int> Registrar(ProductoDTO productoDTO);
		Result<IEnumerable<ProductoGridDTO>> ListarGrid();
		Result<ProductoDTO> Obtener(int id);
		Result Editar(ProductoDTO productoDTO);
	}
	
	public class ProductoBL : BaseBL, IProductoBL
	{
		#region INIT
		private ProductoRepository _repository;
		
		public ProductoBL(IDbConnector db)
		{
			_db = db;
			_repository = new ProductoRepository(_db);
		}	
		#endregion
		
		#region CREATE
			public Result<int> Registrar(ProductoDTO productoDTO)
			{            
				// Inicializaciones
				var result = new Result<int>();
			
				// Acceso al repositorio
				try
				{                
					result.Data = _repository.Registrar(productoDTO);
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
		
		#region READ
			public Result<IEnumerable<ProductoGridDTO>> ListarGrid()
			{
			    // Inicializaciones
			    var result = new Result<IEnumerable<ProductoGridDTO>>();
			
			    // Acceso al repositorio
			    try
			    {
			        result.Data = _repository.ListarGrid();
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
				
			public Result<ProductoDTO> Obtener(int id)
			{
			    // Inicializaciones
			    var result = new Result<ProductoDTO>();
			
			    // Acceso al repositorio
			    try
			    {
			        result.Data = _repository.Obtener(id);
			    }
			    catch (Exception e)
			    {
			        result.Exception = e;
			        result.Message = e.Message;
			        return result;
			    }
			
			    // Salida satisfcatoria
			    result.Success = true;
			    result.Message = "Trasacción realizada satisfactoriamente";
			    return result;
			}	
		#endregion
		
		#region UPDATE
			public Result Editar(ProductoDTO productoDTO)
			        {
			            // Inicializaciones
			            var result = new Result();
			
			            // Editar entidad
			            try
			            {
			                _repository.Editar(productoDTO);
			            }
			            catch (Exception e)
			            {
			                result.Exception = e;
			                result.Message = e.Message;
			                return result;
			            }
			
			            // Salida satisfcatoria
			            result.Success = true;
			            result.Message = "El registro se actualizó satisfactoriamente.";
			            return result;
			        }
				
		#endregion
		
		#region DELETE
		#endregion
		
	}
}
