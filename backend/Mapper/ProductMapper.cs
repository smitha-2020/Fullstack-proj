using backend.src.DTOs;
using backend.src.Models;

namespace backend.Mapper;

public class ProductMapper : BaseMapper
{
    public ProductMapper()
    {
        CreateMap<Product, DTOProductResponse>();
        CreateMap<DTOUpdateProduct, Product>();
        CreateMap<DTOProduct, Product>();
        CreateMap<DTOUpdateProduct, DTOProductResponse>();
        CreateMap<DTOProductResponse, Product>();
    }
}