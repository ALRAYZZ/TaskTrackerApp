using RMTaskTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMTaskTracker;

public class ActionController
{
	public static void Run()
	{
		Console.WriteLine("Welcome to the Task Tracker!");
		Console.WriteLine("Type 'help' to see the list of commands.");



		while (true)
		{
			Console.Write("Enter command: ");
			string input = Console.ReadLine();
			string[] commands = input.Split(' ', 3);
			string action = commands[0].ToLowerInvariant();
			if (action == "help")
			{
				Console.WriteLine("List of commands:");
				Console.WriteLine("list - Lists all tasks");
				Console.WriteLine("list done - Lists all tasks that are done");
				Console.WriteLine("list todo - Lists all tasks that are to do");
				Console.WriteLine("list in-progress - Lists all tasks that are in progress");
				Console.WriteLine("add - Adds a new task");
				Console.WriteLine("update  - Updates a task description");
				Console.WriteLine("delete - Deletes a task");
				Console.WriteLine("mark-in-progress - Marks a task in progress");
				Console.WriteLine("mark-completed - Marks a task completed");
				Console.WriteLine("exit - Exits the application");
			}
			else if (action == "list")
			{
				commands = input.Split(' ', 2);
				if (commands.Length == 1)
				{
					CRUDActions.GetAllTasks();
				}
				else if (commands.Length == 2)
				{
					if (commands[1] == "done")
					{
						CRUDActions.GetAllTasksDone();
					}
					else if (commands[1] == "todo")
					{
						CRUDActions.GetAllTasksToDo();
					}
					else if (commands[1] == "in-progress")
					{
						CRUDActions.GetAllTasksInProgress();
					}
					else
					{
						Console.WriteLine("Wrong status to list. (done/todo/in-progress)");
					}
				}

			}
			else if (action == "add")
			{
				commands = input.Split(' ', 2);
				if (commands.Length == 2)
				{
					
					CRUDActions.AddTask(commands[1]);
				}
				else
				{
					Console.WriteLine("Add command only accepts task description");
				}
			}
			else if (action == "delete")
			{
				if (commands.Length == 2)
				{
					commands = input.Split(' ', 2);
					CRUDActions.DeleteTask(int.Parse(commands[1]));
				}
				else
				{
					Console.WriteLine("Delete command only accepts ID");
				}
			}
			else if (action == "update")
			{
				if (commands.Length == 3)
				{
					commands = input.Split(' ', 3);
					CRUDActions.UpdateTask(int.Parse(commands[1]), commands[2]);
				}
				else
				{
					Console.WriteLine("Update command only accepts ID new task description");
				}
			}
			else if (action == "mark-in-progress")
			{
				if (commands.Length == 2)
				{
					commands = input.Split(' ', 2);
					CRUDActions.MarkTaskInProgress(int.Parse(commands[1]));
				}
			}
			else if (action == "mark-completed")
			{
				if (commands.Length == 2)
				{
					commands = input.Split(' ', 2);
					CRUDActions.MarkTaskCompleted(int.Parse(commands[1]));
				}
			}
			else if (action == "exit")
			{
				break;
			}
			else
			{
				Console.WriteLine("Invalid command. Type 'help' to see the list of commands.");
			}
		}
	}
}
