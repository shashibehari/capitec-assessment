using Capitec.Assessment.Components;
using System;
using System.IO;

namespace Capitec.Assessment.Logic
{

	public static class Validation
	{
		public static string INVALID_ARGUMENTS = "This application must be called with the following arguments: Capitec.Assessment.Feeds.exe userfile tweetfile";
		public static string INVALID_FILE = "The path and/or file could not be found.";
		public static string INVALID_TWEET_LENGTH = "Tweets can only be a maximum of 140 characters.";
		public static string TWEET_FILE_FORMAT = "The format of the tweet file is invalid";
		public static string USER_FILE_FORMAT = "The format of the user file is invalid";

		public static void ValidateArguments(string[] arguments)
		{
			if (arguments == null || arguments.Length != 2)
				throw new ArgumentException(INVALID_ARGUMENTS);
		}
		/// <summary>
		/// Checks whether a file exists
		/// </summary>
		/// <param name="path"></param>
		public static void ValidateFile(string path)
		{
			if (File.Exists(path))
				throw new FileNotFoundException(INVALID_FILE);
		}

		public static void ValidateTweet(Tweet tweet)
		{
			if (tweet.Text.Length > 140)
				throw new InvalidDataException(INVALID_TWEET_LENGTH);
		}
	}
}
