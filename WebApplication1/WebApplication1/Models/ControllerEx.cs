using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
	public static class DataTableQueryString
	{
		public static string OrderingColumn = "order[0][column]";
		public static string OrderingDir = "order[0][dir]";
		public static string Searching = "search[value]";
	}
	public static class ControllerEx
    {
		public static string SearchText(this Controller controller)
		{
			string search = controller.Request.Query["search[value]"];
			return search;
		}

		public static int SearchStatus(this Controller controller)
		{
			int searchStatus = -1;
			int.TryParse(controller.Request.Query["status"], out searchStatus);

			return searchStatus;
		}

		public static void GetDataTableDateRange(this Controller obj, out DateTime? start, out DateTime? end)
		{
			start = null;
			end = null;

			var strStart = obj.Request.Form["dateFrom"].FirstOrDefault();
			DateTime dtStart;
			if (!string.IsNullOrEmpty(strStart) && DateTime.TryParseExact(strStart, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtStart))
			{
				start = dtStart;
			}

			var strEnd = obj.Request.Form["dateTo"].FirstOrDefault();
			DateTime dtEnd;
			if (!string.IsNullOrEmpty(strEnd) && DateTime.TryParseExact(strEnd, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtEnd))
			{
				end = dtEnd.AddDays(1).AddTicks(-1);
			}
		}
		public static void GetDataTablePara(this Controller obj, out string search, out string sortColumn, out string sortDirection)
		{
			search = "";
			sortColumn = "";
			sortDirection = "";

			search = obj.Request.Form[DataTableQueryString.Searching].FirstOrDefault();

			if (obj.Request.Form[DataTableQueryString.OrderingColumn].Count > 0)
			{
				sortColumn = obj.Request.Form[DataTableQueryString.OrderingColumn].First().ToString();

				sortColumn = obj.Request.Form["columns[" + sortColumn + "][name]"].First();
			}

			if (obj.Request.Form[DataTableQueryString.OrderingDir].Count > 0)
			{
				sortDirection = obj.Request.Form[DataTableQueryString.OrderingDir].First();
			}
		}

		public static string SortColumn(this Controller controller)
		{
			string sortColumn = "";
			if (controller.Request.Form["order[0][column]"].Count > 0)
			{
				var columnName = controller.Request.Form["order[0][column]"].First();
				sortColumn = controller.Request.Form["columns[" + columnName + "][name]"].First();
			}

			return sortColumn;
		}

		public static string SortDirection(this Controller controller)
		{
			string sortDirection = "asc";
			if (controller.Request.Form["order[0][dir]"].Count > 0)
			{
				sortDirection = controller.Request.Form["order[0][dir]"];
			}

			return sortDirection;
		}

	}
}
