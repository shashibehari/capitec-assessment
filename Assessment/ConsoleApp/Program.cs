using Capitec.Assessment.Components;
using Capitec.Assessment.Logic;
using System;
using System.Collections.Generic;

namespace Capitec.Assessment.Feeds
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{				
				Validation.ValidateArguments(args);
				Console.WriteLine("Beginning feed processing with the following: ");
				Console.WriteLine($"User file path: { args[0] }");
				Console.WriteLine($"Tweet file path: { args[0] }");
				Console.Write("Are you OK with this? Y/N: ");
				if (Console.ReadLine().ToUpper() == "Y")
				{
					FeedManager manager = new FeedManager();
					Console.WriteLine(manager.ProcessFiles(args[0], args[1]));
				}						
			}
			catch (Exception exception)
			{
				Console.Write("Error processing feed:");
				Console.WriteLine(exception.Message);
			}
			finally
			{
				Console.Write("Press any key to exit");
				Console.ReadLine();
			}
		}
	}
}
