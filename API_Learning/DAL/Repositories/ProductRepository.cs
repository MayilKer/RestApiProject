using API_Learning.DAL.Entities;
using API_Learning.DTOs.ProductDtos;
using API_Learning.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int? id)
        {
            Product existProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            existProduct.DeletedAt = DateTime.UtcNow.AddHours(4);
            existProduct.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductListDto>> Get()
        {
            List<ProductListDto> productList = await _context.Products.Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                DiscountPrice = p.DiscountPrice,
                IsDeleted = p.IsDeleted
            }).ToListAsync();

            return productList;
        }

        public async Task<ProductDetailDto> Get(int? id)
        {

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product != null)
            {
                ProductDetailDto productDetail = new ProductDetailDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    DiscountPrice = product.DiscountPrice,
                    IsDeleted = product.IsDeleted
                };
                return productDetail;
            }

            return null;
        }

        public async Task<ProductPostDto> Post(ProductPostDto productPostDto)
        {
            Product product = new Product
            {
                Name = productPostDto.Name,
                Price = productPostDto.Price,
                DiscountPrice = productPostDto.DiscountPrice,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return productPostDto;
            
        }

        public async Task<ProductPutDto> Put(ProductPutDto productPutDto)
        {
            Product existProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productPutDto.Id && !p.IsDeleted);

            existProduct.Name = productPutDto.Name;
            existProduct.Price = productPutDto.Price;
            existProduct.DiscountPrice = productPutDto.DiscountPrice;
            existProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return productPutDto;
        }
    }
}
