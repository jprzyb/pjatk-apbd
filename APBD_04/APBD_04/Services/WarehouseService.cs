using APBD_04.Model;
using APBD_04.Repositories;

namespace APBD_04.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(WarehouseRespository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public int AddProductToWarehouse(Product product)
    {
        return _warehouseRepository.AddProductToWarehouse(product);
    }
}