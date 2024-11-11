using APBD_04.Model;

namespace APBD_04.Repositories;

public interface IWarehouseRepository
{
    int AddProductToWarehouse(Product product);

}