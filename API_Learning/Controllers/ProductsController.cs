using API_Learning.DAL;
using API_Learning.DAL.Entities;
using API_Learning.DTOs.ProductDtos;
using API_Learning.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _products;
        public ProductsController(IProductRepository products)
        {
            _products = products;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductPostDto productPostDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _products.Post(productPostDto));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _products.Get());
        }
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return BadRequest();

            var product = await _products.Get(id);

            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, ProductPutDto productPutDto)
        {
            if (id == null) return BadRequest();

            if (id != productPutDto.Id) return NotFound();

            var existProduct = await _products.Get(id);

            if (existProduct == null) return NotFound();

            var listProduct = await _products.Get();          

            if(listProduct.Any(p=>p.Id != existProduct.Id && p.Name == productPutDto.Name)) return StatusCode(StatusCodes.Status405MethodNotAllowed, "Name already Exsist");

            await _products.Put(productPutDto);

            return NoContent();
        }
        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var existProduct = await _products.Get(id);

            if (existProduct == null) return NotFound();

            await _products.Delete(id);

            return Ok();
        }
    }
}
