using AutoMapper;
using GeekShopping.CouponAPI.Model;

namespace GeekShopping.CouponAPI.Config
{
	public class MapperConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config => {
				//config.CreateMap<ProductVO, Product>().ReverseMap();
			});
			return mappingConfig;
		}
	}
}
