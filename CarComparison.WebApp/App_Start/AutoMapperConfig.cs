using AutoMapper;
using CarComparison.Common.Data;
using CarComparison.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarComparison.WebApp.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CarModel, Car>();
                cfg.CreateMap<Car, CarModel>();
            });
        }
    }
}