using API_Learning.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductListDto>> Get();
        Task<ProductDetailDto> Get(int? id);
        Task<ProductPutDto> Put(ProductPutDto productPutDto);
        Task<ProductPostDto> Post(ProductPostDto productPostDto);
        Task Delete(int? id);
    }
}
