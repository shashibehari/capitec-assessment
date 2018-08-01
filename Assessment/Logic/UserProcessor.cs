using Capitec.Assessment.Components;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capitec.Assessment.Logic
{
	public class UserProcessor
	{
		/// <summary>
		/// Read a file containing users and their followers, and return a user mapping
		/// </summary>
		/// <param name="userFile"></param>
		/// <returns></returns>
		public static UserMappings BuildUserList(string userFileName)
		{
			var users = new UserMappings();
			string[] fileLines = File.ReadAllLines(userFileName);

			foreach (var line in fileLines)
			{
				var splitLine = line.Split(new string[] { Settings.Default.FollowsPattern, Settings.Default.Seperator }, StringSplitOptions.RemoveEmptyEntries);
				if (splitLine != null && splitLine.Length > 1)
				{
					var followerName = splitLine[0].Trim();
					
					for (int index = splitLine.Length - 1; index > 0; --index)
					{
						var userName = splitLine[index].Trim();
						users.AddUserAndFollower(userName, followerName);
					}
				}
				else
					throw new FormatException(Validation.USER_FILE_FORMAT);
			}
			return users;
		}
	}
}