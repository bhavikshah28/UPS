﻿using UPS.Application.Common.Mappings;
using UPS.Domain.Entities;
using AutoMapper;

namespace UPS.Application.Features.Products.Queries.GetProductsFile
{
    public class ProductRecordDto : IMapFrom<Product>
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductRecordDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ProductName))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        }
    }
}
