using Capitec.Assessment.Components;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capitec.Assessment.Logic
{
	public static class TweetProcessor
	{
		/// <summary>
		/// Build a list of tweets from a given file
		/// </summary>
		/// <param name="tweetFile"></param>
		/// <returns></returns>
		public static List<Tweet> BuildTweets(string tweetFile)
		{
			var tweets = new List<Tweet>();
			string[] fileLines = File.ReadAllLines(tweetFile);

			foreach (var line in fileLines)
			{
				var splitLine = line.Split(new string[] { Settings.Default.TweetSeparator }, StringSplitOptions.RemoveEmptyEntries);
				if (splitLine != null && splitLine.Length == 2)
				{
					var tweet = new Tweet() { UserName = splitLine[0], Text = splitLine[1] };
					Validation.ValidateTweet(tweet);
					tweets.Add(tweet);
				}
				else
					throw new FormatException(Validation.TWEET_FILE_FORMAT);
			}
			return tweets;
		}
	}
}
