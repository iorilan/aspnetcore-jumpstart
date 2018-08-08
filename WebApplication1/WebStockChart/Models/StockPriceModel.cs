using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStockChart.Models
{
	public class StockPriceModel
	{
		public string Ticker { get; set; }
		public string Date { get; set; }
		public decimal Open { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public decimal Close { get; set; }
		public decimal AdjustedClose { get; set; }
		public decimal Volume { get; set; }
	}
}
