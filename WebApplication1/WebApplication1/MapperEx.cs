using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApplication1
{
	public static class MapperEx
	{
		public static TTo CreateFrom<TFrom, TTo>(TFrom from)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>());
			var mapper = config.CreateMapper();
			return mapper.Map<TTo>(from);
		}

		public static void Map<TFrom, TTo>(TFrom from, ref TTo to)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>());
			var mapper = config.CreateMapper();
			mapper.Map(from, to);
		}
		public static void MapExceptID<TFrom, TTo>(TFrom from, ref TTo to)
		{
			var idProperty = to.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == "id");
			object idValue = null;
			if (idProperty != null)
			{
				idValue = idProperty.GetValue(to);
			}


			var config = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>());
			var mapper = config.CreateMapper();
			mapper.Map(from, to);


			////if 'Id' Property exists in Original Object , keep the id and put in new object
			////the reason of doing this is because 'id' is the primary key and should not be modified
			if (idProperty != null && idValue != null)
			{
				idProperty.SetValue(to, idValue);
			}
		}
	}
}
