using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public static class LinQHelper
	{
		public static IQueryable<T> OrderByEx<T>(this IQueryable<T> q, string direction, string fieldName)
		{
			try
			{
				var customProperty = typeof(T).GetCustomAttributes(false).OfType<ColumnAttribute>().FirstOrDefault();
				if (customProperty != null)
				{
					fieldName = customProperty.Name;
				}

				var param = Expression.Parameter(typeof(T), "p");
				var prop = Expression.Property(param, fieldName);
				var exp = Expression.Lambda(prop, param);
				string method = direction.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
				Type[] types = new Type[] { q.ElementType, exp.Body.Type };
				var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
				return q.Provider.CreateQuery<T>(mce);
			}
			catch (Exception ex)
			{
				// TODO , add log here
				throw;
			}
		}


	}
}
