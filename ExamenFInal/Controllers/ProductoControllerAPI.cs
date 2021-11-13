using AutoMapper;
using ExamenFInal.Models;
using ExamenFInal.Models.DTOs;
using ExamenFInal.Repository.iRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoControllerAPI : Controller
    {
        private readonly iProductoRepository _ctoProducto;
        private readonly IMapper _mapper;

        public ProductoControllerAPI(iProductoRepository ctoProducto, IMapper mapper) {
            _ctoProducto = ctoProducto;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaProducto()
        {
            var nListarProducto = _ctoProducto.GetProductoModels();
            var nListarProductoDto = new List<ProductoDto>();

            foreach (var nListar in nListarProducto)
            {
                nListarProductoDto.Add(_mapper.Map<ProductoDto>(nListar));
            }
            return Ok(nListarProductoDto);
        }
        [HttpGet("{nIdProducto:int}", Name = "GetProductoById")]
        public IActionResult GetProductoByID(int nIdProducto)
        {
            var ListarProducto = _ctoProducto.GetProducto(nIdProducto);
            if (ListarProducto == null)
            {
                NotFound();
            }
            var nRegistroProducto = _mapper.Map<ProductoDto>(ListarProducto);
            return Ok(nRegistroProducto);
        }
        [HttpPost]
        public IActionResult CreaProducto([FromBody] ProductoSaveDto ProductoDto)
        {
            if (ProductoDto == null) {
                return BadRequest(ModelState);
            }
            var Producto = _mapper.Map<ProductoModel>(ProductoDto);
            if (!_ctoProducto.CrearProducto(Producto))
            {
                ModelState.AddModelError("", $"Ocurrio un error al grabar el registro {Producto.IdProducto}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetProductoById", new { nIdProveedor = ProductoDto.IdProveedor }, Producto);
        }
    }
}
