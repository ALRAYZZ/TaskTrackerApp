using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RMTaskTracker.Models;

public class TodoTask
{
	[Required]
	public int Id { get; set; }
	[Required]
	public string Description { get; set; }
	public TaskStatus Status { get; set; } = TaskStatus.ToDo;
	[Required]
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;

	[JsonIgnore]
	public string TaskInfo => $"Task ID: {Id}, Description: {Description}, Status: {Status}, Created At: {CreatedAt}, Updated At: {UpdatedAt}";
}
public enum TaskStatus
{
	ToDo,
	InProgress,
	Completed
}
