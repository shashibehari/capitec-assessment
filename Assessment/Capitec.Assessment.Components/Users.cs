using System;
using System.Collections.Generic;
using System.Linq;
namespace Capitec.Assessment.Components
{
	public class UserMappings
	{
		public UserMappings()
		{
			UserFollowerMapping = new Dictionary<string, List<string>>();
			FollowerUserMapping = new Dictionary<string, List<string>>();
		}
		public List<string> AllUsers { get { return UserFollowerMapping.Keys.Union(FollowerUserMapping.Keys).OrderBy(u => u).ToList(); } }
		public Dictionary<string, List<string>> UserFollowerMapping { get; set; }

		public Dictionary<string, List<string>> FollowerUserMapping { get; set; }

		public void AddUserAndFollower(string userName, string followerName)
		{
			AddToDictionary(UserFollowerMapping, userName, followerName);
			AddToDictionary(FollowerUserMapping, followerName, userName);
		}

		private void AddToDictionary(Dictionary<string, List<string>> dictionary, string key, string value)
		{
			// We don't have the key yet, add it
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, new List<string>() { value });
			}
			else
			{
				// We don't have the value on this key yet, add it
				if (!dictionary[key].Contains(value))
				{
					dictionary[key].Add(value);
				}
			}
		}
	}
}
