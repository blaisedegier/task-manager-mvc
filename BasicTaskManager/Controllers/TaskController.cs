using Microsoft.AspNetCore.Mvc;
using BasicTaskManager.Models;

namespace BasicTaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskModel> taskList = new List<TaskModel>();

        public IActionResult Index()
        {
            return View(taskList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.Id = taskList.Count > 0 ? taskList.Max(t => t.Id) + 1 : 1;
                taskList.Add(task);
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var existingTask = taskList.FirstOrDefault(t => t.Id == id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Deadline = task.Deadline;

                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = taskList.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            taskList.Remove(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
