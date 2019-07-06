using BusinessLogic.INVENTARIOS;
using Common.Utils;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Models.INVENTARIOS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;


namespace Web.Areas.INVENTARIOS.Controllers
{
	public class ProductoController : BaseController
    {
    	#region INIT
		private ProductoBL _bl;        
		
		public ProductoController() 
		{
			_db = new DapperSqlServerConnector();
			_bl = new ProductoBL(_db);
		}
    	#endregion
    	
    	#region CREATE
    		[HttpGet]
    		public ActionResult Registrar()
    		{
    		    return PartialView();
    		}
    		
    		[HttpPost]
    		public JsonResult Registrar(ProductoDTO productoDTO)
    		{
    		    // Inicializaciones
    		    var result = new Result<int>();
    		
    		    // Validaciones
    		    if (!ModelState.IsValid)
    		    {
    		        result.Success = false;
    		        result.Message = "Verifique la información registrada previmente.";
    		        return Json(result);
    		    }
    		
    		    // Acceso a logicas de negocio
    		    var registrar = _bl.Registrar(productoDTO);
    		    if (!registrar.Success)
    		    {
    		        result.Message = registrar.Message;
    		        result.Success = false;
    		        return Json(result);
    		    }
    		
    		    // Salida
    		    result.Success = true;
    		    result.Message = registrar.Message;
    		    result.Data = registrar.Data;
    		
    		    return Json(result);
    		}	
		#endregion
			
    	#region READ
			public ActionResult Index()
			{
				return View();
			}
			 
			 
			public JsonResult ListarGrid([DataSourceRequest]DataSourceRequest request)
			{
			
				var listarGrid = _bl.ListarGrid();
				if (!listarGrid.Success)
				{
					ModelState.AddModelError("Error", listarGrid.Message);
					return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
				}
			
				//Salida Success 
				var ds = new DataSourceResult()
				{
					Data = listarGrid.Data,
					Total = listarGrid.Data.Count()
				};
				return Json(ds);
			}
			 
    	#endregion
			
    	#region UPDATE
    		[HttpGet]
    		public ActionResult Editar(int id)
    		{
    		    var obtener = _bl.Obtener(id);
    		    if (!obtener.Success) {
    		        ModelState.AddModelError("Error", obtener.Message);
    		        return PartialView();
    		    }
    		
    		    return PartialView(obtener.Data);
    		}
    		
    		[HttpPost]
    		public JsonResult Editar(ProductoDTO productoDTO)
    		{
    		    // Inicializaciones
    		    var result = new Result();
    		
    		    // Validaciones
    		    if (!ModelState.IsValid)
    		    {
    		        result.Success = false;
    		        result.Message = "Verifique la información registrada previmente.";
    		        return Json(result);
    		    }
    		
    		    // Acceso a logicas de negocio
    		    var editar = _bl.Editar(productoDTO);
    		    if (!editar.Success)
    		    {
    		        result.Success = false;
    		        result.Message = editar.Message;                
    		        return Json(result);
    		    }
    		
    		    // Salida
    		    result.Success = true;
    		    result.Message = editar.Message;
    		
    		    return Json(result);
    		}
		#endregion
		
    	#region DELETE
		#endregion	
    }
}
