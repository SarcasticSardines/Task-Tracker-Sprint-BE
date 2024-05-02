using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksprintbe.Models;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Services
{
    public class TaskService
    {

        private readonly DataContext _context;

        public TaskService(DataContext context)
        {
            _context = context;
        }

        public bool AddTaskItem(TaskModel newTaskItem)
        {
            _context.Add(newTaskItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<TaskModel> GetAllTaskItems()
        {
            return _context.TaskInfo;
        }

        public IEnumerable<TaskModel> GetItemsByUsername(string username)
        {
            return _context.TaskInfo.Where(item => item.Username == username);
        }


        public IEnumerable<TaskModel> GetItemsByTitle(string title)
        {
            return _context.TaskInfo.Where(item => item.Title == title);
        }

        public IEnumerable<TaskModel> GetItemsByDate(string date)
        {
            return _context.TaskInfo.Where(item => item.DateCreated == date);
        }

        public IEnumerable<TaskModel> GetItemsByAssigned(string assignedTo)
        {
            return _context.TaskInfo.Where(item => item.AssignedTo == assignedTo);
        }

        public IEnumerable<TaskModel> GetItemsByStatus(string status)
        {
            return _context.TaskInfo.Where(item => item.Status == status);
        }

        public IEnumerable<TaskModel> GetItemsByPriority(string priority)
        {
            return _context.TaskInfo.Where(item => item.Priority == priority);
        }

        public TaskModel GetTaskItemById(int id)
        {
            return _context.TaskInfo.SingleOrDefault(item => item.ID == id);
        }

        public bool UpdateTaskItem(TaskModel taskUpdate)
        {
            _context.Update<TaskModel>(taskUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool DeleteTaskItem(TaskModel taskToDelete)
        {
            taskToDelete.IsDeleted = true;
            _context.Update<TaskModel>(taskToDelete);
            return _context.SaveChanges() != 0;
        }
    }
}