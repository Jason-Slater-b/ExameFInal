using AutoMapper;
using ExamenFInal.Models;
using ExamenFInal.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Mapper
{
    public class ProductoMappers:Profile
    {
        public ProductoMappers()
        {
            CreateMap<ProductoModel, ProductoDto>().ReverseMap();
            CreateMap<ProductoModel, ProductoSaveDto>().ReverseMap();
        }
    }
}
