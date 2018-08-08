using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStockChart.Models;
using YahooFinanceApi;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStockChart.Controllers
{
	[Produces("application/json")]
	public class ApiStockDataController : Controller
	{
		//http://localhost:29321/api/apistockdata/ibm/2018-01-01/2018-02-01/daily
		[Route("~/api/ApiStockData/{ticker}/{start}/{end}/{period}")]
		[HttpGet]
		public async Task<List<StockPriceModel>> GetStockData(string ticker, string start,
			string end, string period)
		{
			var p = Period.Daily;
			if (period.ToLower() == "weekly") p = Period.Weekly;
			else if (period.ToLower() == "monthly") p = Period.Monthly;
			var startDate = DateTime.Parse(start);
			var endDate = DateTime.Parse(end);

			var hist = await Yahoo.GetHistoricalAsync(ticker, startDate, endDate, p);

			List<StockPriceModel> models = new List<StockPriceModel>();
			foreach (var r in hist)
			{
				models.Add(new StockPriceModel
				{
					Ticker = ticker,
					Date = r.DateTime.ToString("yyyy-MM-dd"),
					Open = r.Open,
					High = r.High,
					Low = r.Low,
					Close = r.Close,
					AdjustedClose = r.AdjustedClose,
					Volume = r.Volume
				});
			}
			return models;
		}

		[Route("~/Stock/Chart")]
		public IActionResult StockChart()
		{
			return View();
		}
	}
}
