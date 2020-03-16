using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoxml
{
	public class Calciatore
	{
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public string Squadra { get; set; }
		public DateTime Data { get; set; }

		public override string ToString()
		{
			return $"{Nome} {Cognome}";
		}
	}
}
