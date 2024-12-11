using RMTaskTracker.Models;
using RMTaskTracker.Utillities;
using TaskStatus = RMTaskTracker.Models.TaskStatus;

namespace RMTaskTracker.DataAccess;

public static class CRUDActions
{
	public static void GetAllTasks()
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		Console.WriteLine("Getting all tasks...");
		foreach (var task in tasks)
		{
			Console.WriteLine(task.TaskInfo);
		}
	}
	public static void GetTaskById(int id)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		Console.WriteLine("Getting task by ID...");

		foreach (var task in tasks)
		{
			if (task.Id == id)
			{
				Console.WriteLine(task.TaskInfo);
			}
			else
			{
				Console.WriteLine($"Task ID: {id} not found.");
			}
		}
	}

	public static void AddTask(string taskName)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		

		TodoTask task = new TodoTask();
		task.Id = tasks.Last().Id + 1;
		task.Description = taskName;
		tasks.Add(task);
		Console.WriteLine("Adding task...");
		JsonHelper.WriteTaskToJsonFile(tasks);
		
		Console.WriteLine($"You wrote: {task.Description}");
	}
	public static void DeleteTask(int id)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Id == id)
			{
				tasks.Remove(task);
				taskFound = true;
				break;
			}
		}
		if (taskFound)
		{
			Console.WriteLine("Removing task...");
			JsonHelper.WriteTaskToJsonFile(tasks);
		}
		else
		{
			Console.WriteLine($"Task ID: {id} not found.");
		}
	}
	public static void UpdateTask(int id, string description)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Id == id)
			{
				task.Description = description;
				task.UpdatedAt = DateTime.Now;
				taskFound = true;
				break;
			}
		}
		if (taskFound)
		{
			JsonHelper.WriteTaskToJsonFile(tasks);
			Console.WriteLine("Updating task...");
		}
		else
		{
			Console.WriteLine($"Task ID: {id} not found.");
		}
	}

	public static void MarkTaskInProgress(int id)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		bool taskFound = false;

		foreach (var task in tasks) 
		{
			if (task.Id == id) 
			{
				task.Status = TaskStatus.InProgress;
				task.UpdatedAt = DateTime.Now;
				taskFound = true;
				break;
			}
		}
		if (taskFound)
		{
			JsonHelper.WriteTaskToJsonFile(tasks);
			Console.WriteLine($"Task ID: {id} marked as In Progress");
		}
		else
		{
			Console.WriteLine($"Task ID: {id} not found.");
		}
	}

	internal static void MarkTaskCompleted(int id)
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Id == id)
			{
				task.Status = TaskStatus.Completed;
				task.UpdatedAt = DateTime.Now;
				taskFound = true;
				break;
			}
		}
		if (taskFound)
		{
			JsonHelper.WriteTaskToJsonFile(tasks);
			Console.WriteLine($"Task ID: {id} marked as Completed");
		}
		else
		{
			Console.WriteLine($"Task ID: {id} not found.");
		}
	}

	internal static void GetAllTasksDone()
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		Console.WriteLine("Getting completed tasks...");
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Status == TaskStatus.Completed)
			{
				Console.WriteLine(task.TaskInfo);
				taskFound = true;
			}
		}
		if (!taskFound)
		{
			Console.WriteLine("No task done found");
		}
	}

	internal static void GetAllTasksToDo()
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		Console.WriteLine("Getting To Do tasks...");
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Status == TaskStatus.ToDo)
			{
				Console.WriteLine(task.TaskInfo);
				taskFound = true;
			}
		}
		if (!taskFound)
		{
			Console.WriteLine("No task to do found");
		}
	}

	internal static void GetAllTasksInProgress()
	{
		List<TodoTask> tasks = JsonHelper.ReadTasksFromJsonFile();
		Console.WriteLine("Getting In Progress tasks...");
		bool taskFound = false;

		foreach (var task in tasks)
		{
			if (task.Status == TaskStatus.InProgress)
			{
				Console.WriteLine(task.TaskInfo);
				taskFound = true;
			}
		}
		if (!taskFound)
		{
			Console.WriteLine("No task in progress found");
		}
	}
}
