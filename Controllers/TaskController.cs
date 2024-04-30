using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasksprintbe.Models;
using tasksprintbe.Services;

namespace tasksprintbe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _data;

        public TaskController(TaskService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("AddTaskItem")]
        public bool AddTaskItem(TaskModel newTaskItem)
        {
            return _data.AddTaskItem(newTaskItem);
        }

        [HttpGet]
        [Route("GetAllTaskItems")]
        public IEnumerable<TaskModel> GetAllTaskItems()
        {
            return _data.GetAllTaskItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId")]
        public IEnumerable<TaskModel> GetItemsByUserId(int userId)
        {
            return _data.GetItemsByUserId(userId);
        }

        [HttpGet]
        [Route("GetItemsByTitle")]
        public IEnumerable<TaskModel> GetItemsByTitle(string title)
        {
            return _data.GetItemsByTitle(title);
        }

        [HttpGet]
        [Route("GetItemsByDate")]
        public IEnumerable<TaskModel> GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

        [HttpGet]
        [Route("GetItemsByAssigned")]
        public IEnumerable<TaskModel> GetItemsByAssigned(string assignedTo)
        {
            return _data.GetItemsByAssigned(assignedTo);
        }

        [HttpGet]
        [Route("GetItemsByStatus")]
        public IEnumerable<TaskModel> GetItemsByStatus(string status)
        {
            return _data.GetItemsByStatus(status);
        }

        [HttpGet]
        [Route("GetItemsByPriority")]
        public IEnumerable<TaskModel> GetItemsByPriority(string priority)
        {
            return _data.GetItemsByPriority(priority);
        }

        [HttpGet]
        [Route("GetTaskItemById/{id}")]
        public TaskModel GetTaskItemById(int id)
        {
            return _data.GetTaskItemById(id);
        }

        [HttpPut]
        [Route("UpdateTaskItem")]
        public bool UpdateTaskItem(TaskModel taskUpdate)
        {
            return _data.UpdateTaskItem(taskUpdate);
        }


        [HttpDelete]
        [Route("DeleteTaskItem")]
        public bool DeleteTaskItem(TaskModel taskToDelete)
        {
            return _data.DeleteTaskItem(taskToDelete);
        }
    }
}