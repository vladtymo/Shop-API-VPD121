using BusinessLogic.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            // Product -> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // ProductDto -> Product
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Category, opt => opt.Ignore());
        }
    }
}
