using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.TaskHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class AddTaskService : IAddTask
    {
        TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
        /// <summary> Add Task 
        public Tasks AddTask(TaskModel task)
        {
            try
            {
                Tasks _task = new Tasks();
                _task = TaskHelper.ConvertTaskModeltoTask(task);
                _DBContext.Tasks.Add(_task);
                _DBContext.SaveChanges();
                return _task;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
