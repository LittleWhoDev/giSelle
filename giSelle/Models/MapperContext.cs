using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public static class MapperContext {
        static public MapperConfiguration config { get; }
        static public IMapper mapper { get; }

        static MapperContext()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductViewModel, Product>();
            });

            mapper = config.CreateMapper();
        }
    }
}