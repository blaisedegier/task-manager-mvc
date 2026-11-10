using Microsoft.AspNetCore.Mvc;
using BasicTaskManager.Models;

namespace BasicTaskManager.Controllers
{
    public class TaskController : Controller
    {
        // Tasks live in memory for the lifetime of the process. Controllers are created per request,
        // so the list is static and every access goes through the lock.
        private static readonly List<TaskModel> taskList = new List<TaskModel>();
        private static readonly object taskListLock = new object();

        public IActionResult Index()
        {
            lock (taskListLock)
            {
                return View(taskList.OrderBy(t => t.Deadline).ToList());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            lock (taskListLock)
            {
                task.Id = taskList.Count > 0 ? taskList.Max(t => t.Id) + 1 : 1;
                taskList.Add(task);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var task = Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            lock (taskListLock)
            {
                var existingTask = taskList.FirstOrDefault(t => t.Id == id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Deadline = task.Deadline;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var task = Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            lock (taskListLock)
            {
                var task = taskList.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    return NotFound();
                }

                taskList.Remove(task);
            }

            return RedirectToAction(nameof(Index));
        }

        private static TaskModel? Find(int id)
        {
            lock (taskListLock)
            {
                return taskList.FirstOrDefault(t => t.Id == id);
            }
        }
    }
}
