﻿using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
	public class MapperConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config => {
				config.CreateMap<ProductVO, Product>().ReverseMap();
				config.CreateMap<CartVO, Cart>().ReverseMap();
				config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
				config.CreateMap<CartDetailsVO, CartDetails>().ReverseMap();

			});
			return mappingConfig;
		}
	}
}
