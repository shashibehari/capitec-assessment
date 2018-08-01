using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitec.Assessment.Components
{
	public class Tweet
	{
		public string UserName { get; set; }
		public string Text { get; set; }

		public override string ToString()
		{
			return $"@{ UserName }: { Text }";
		}
	}
}
