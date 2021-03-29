using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RestSharpLib.Models.NBP
{
	[XmlRoot(ElementName = "Rate")]
	public class Rate
	{

		[XmlElement(ElementName = "No")]
		public string No { get; set; }

		[XmlElement(ElementName = "EffectiveDate")]
		public DateTime EffectiveDate { get; set; }

		[XmlElement(ElementName = "Mid")]
		public DateTime Mid { get; set; }
	}

	[XmlRoot(ElementName = "Rates")]
	public class Rates
	{

		[XmlElement(ElementName = "Rate")]
		public Rate Rate { get; set; }
	}

	[XmlRoot(ElementName = "ExchangeRatesSeries")]
	public class ExchangeRatesSeries
	{

		[XmlElement(ElementName = "Table")]
		public string Table { get; set; }

		[XmlElement(ElementName = "Currency")]
		public string Currency { get; set; }

		[XmlElement(ElementName = "Code")]
		public string Code { get; set; }

		[XmlElement(ElementName = "Rates")]
		public Rates Rates { get; set; }
	}

}
