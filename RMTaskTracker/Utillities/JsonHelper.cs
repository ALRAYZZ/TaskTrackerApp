using RMTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RMTaskTracker.Utillities;

public static class JsonHelper
{
	private static readonly string filePath = Path.Combine
		(Directory.GetCurrentDirectory(), "Database", "Tasks.json");

	public static void WriteTaskToJsonFile(List<TodoTask> tasks)
	{
		var options = new JsonSerializerOptions { WriteIndented = true };
		string updatedJsonString = JsonSerializer.Serialize(tasks, options);
		Directory.CreateDirectory(Path.GetDirectoryName(filePath));
		File.WriteAllText(filePath, updatedJsonString);
	}

	public static List<TodoTask> ReadTasksFromJsonFile()
	{
		if (File.Exists(filePath))
		{
			string jsonString = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<List<TodoTask>>(jsonString);
		}
		else
		{
			return new List<TodoTask>();
		}
	}


}
