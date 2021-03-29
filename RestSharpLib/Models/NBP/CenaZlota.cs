using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RestSharpLib.Models
{
	[XmlRoot(ElementName = "CenaZlota")]
	public class CenaZlota
	{
		[XmlElement(ElementName = "Data")]
		public string Data { get; set; }
		[XmlElement(ElementName = "Cena")]
		public double Cena { get; set; }
	}

}
