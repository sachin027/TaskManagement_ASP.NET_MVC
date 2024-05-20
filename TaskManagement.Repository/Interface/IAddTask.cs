using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface
{
    public interface IAddTask
    {
        /// <summary>Add task interface
        bool AddTask(TaskModel _taskModel);

    }
}
