﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoFramework.Core
{
	public static class MongoDbUtility
	{
		public static MongoUrl GetMongoUrlFromConfig(string connectionName)
		{
			var connectionStringConfig = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName];

			if (connectionStringConfig != null)
			{
				return MongoUrl.Create(connectionStringConfig.ConnectionString);
			}

			return null;
		}

		public static IMongoDatabase GetDatabase(MongoUrl mongoUrl)
		{
			return GetDatabase(mongoUrl.Url, mongoUrl.DatabaseName);
		}

		public static IMongoDatabase GetDatabase(string connectionString, string databaseName)
		{
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(databaseName);
			return database;
		}

		/// <summary>
		/// Checks whether the provided string matches the 24-character hexadecimal format of an ObjectId
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static bool IsValidObjectId(string id)
		{
			ObjectId result;
			return ObjectId.TryParse(id, out result);
		}
	}
}
