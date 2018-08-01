using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitec.Assessment.Components;

namespace Capitec.Assessment.Logic
{
	public class FeedManager
	{
		/// <summary>
		/// Converts a user file and tweet file into a feed 
		/// </summary>
		/// <param name="userFile"></param>
		/// <param name="tweetFile"></param>
		/// <returns></returns>
		public string ProcessFiles(string userFile, string tweetFile)
		{
			var users = UserProcessor.BuildUserList(userFile);
			var tweets = TweetProcessor.BuildTweets(tweetFile);
			return FormatFeed(users, tweets);
		}
		/// <summary>
		/// Format tweets by user and their feed 
		/// </summary>
		/// <param name="users"></param>
		/// <param name="tweets"></param>
		/// <returns></returns>
		private string FormatFeed(UserMappings users, List<Tweet> tweets)
		{
			StringBuilder stringBuilder = new StringBuilder();
			var sortedUsers = users.AllUsers;
			foreach (string user in sortedUsers)
			{
				stringBuilder.AppendLine(user);
				// get the current user's tweets
				List<Tweet> feed = GetTweetsForFeed(tweets, user);

				// get the current user's tweets from whomever they follow
				if (users.FollowerUserMapping.ContainsKey(user))
					feed.AddRange(GetTweetsForFeed(tweets, users.FollowerUserMapping[user]));

				foreach (Tweet tweet in feed)
					stringBuilder.AppendLine($"\t{ tweet }");
			}
			return stringBuilder.ToString();
		}
		private List<Tweet> GetTweetsForFeed(List<Tweet> tweets, string user)
		{
			return GetTweetsForFeed(tweets, new List<string> { user });
		}

		private List<Tweet> GetTweetsForFeed(List<Tweet> tweets, List<string> users)
		{
			return tweets.FindAll(t => users.Contains(t.UserName));
		}
	}
}

