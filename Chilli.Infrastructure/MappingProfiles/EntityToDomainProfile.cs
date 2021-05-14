using AutoMapper;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Product.Models;
using Chilli.Core.Product.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.MappingProfiles
{
    public class EntityToDomainProfile: Profile
    {
        public EntityToDomainProfile()
        {
            CreateMap<AddProductRequest, ProductEntity>();
            CreateMap<PutProductRequest, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();
        }   
    }
}
