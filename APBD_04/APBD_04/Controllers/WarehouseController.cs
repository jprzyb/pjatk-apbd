using APBD_04.Model;
using APBD_04.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_04.Controlers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
    
    /// <summary>
    /// Endpoints used to return Add Product To Warehouse.
    /// </summary>
    /// <param name="product">New product data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult AddProductToWarehouse(Product product)
    {
        var key = _warehouseService.AddProductToWarehouse(product);
        return StatusCode(StatusCodes.Status201Created);
    }
}