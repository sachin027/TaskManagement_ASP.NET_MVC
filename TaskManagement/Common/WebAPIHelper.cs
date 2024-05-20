using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Common
{
    public class WebAPIHelper
    {
        public static string ApiUrl = "http://localhost:63373/api/";
        /// <summary> Return Completed Student List
        public static async Task<List<AssignmentModelList>> CompletedStudentList()
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"TeacherAPI/AList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _assignmentList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            }; 
            return _assignmentList;
        }
        /// <summary> Return Pending Student List
        public static async Task<List<AssignmentModelList>> PendingStudentList()
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"TeacherAPI/GetPendingTaskStudentList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _assignmentList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _assignmentList;
        }
        /// <summary> Return All task assigned Student List
        public static async Task<List<AssignmentModelList>> GetAllTaskAssignedStudentList()
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"TeacherAPI/GetAllTaskAssignedStudentList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _taskList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _taskList;
        }
        /// <summary> Return Completed assignment List
        public static async Task<List<AssignmentModelList>> CompleteAssignmentList()
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/CompletedAssignmentListByStudent?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _taskList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _taskList;
        }
        /// <summary> Return pending assignment List
        public static async Task<List<AssignmentModelList>> PendingAssignmentList()
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/PendingAssignmentListByStudent?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _taskList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _taskList;
        }
        /// <summary> Return All Created Task List
        public static async Task<List<CustomTaskModel>> GetCustomTaskList()
        {
            List<CustomTaskModel> _assignmentList = new List<CustomTaskModel>();
            string username = SessionHelper.SessionHelper.Username;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"TeacherAPI/GetCustomTaskList?username={username}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _assignmentList = JsonConvert.DeserializeObject<List<CustomTaskModel>>(responseData);
                }
            };
            return _assignmentList;
        }
        /// <summary> Create Task
        public static async Task<bool> CreateTask(TaskModel task)
        {
            string username = SessionHelper.SessionHelper.Username;
            bool ans = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                string content = JsonConvert.SerializeObject(task);
                var response = await client.PostAsync($"TeacherAPI/CreateTask",new StringContent(content, Encoding.UTF8, "application/json"));
                
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    ans  = JsonConvert.DeserializeObject<bool>(responseData);
                }

                return ans;
            };
        }
        /// <summary> Assign Task to Student
        public static async Task<bool> AssignTask(AssignmentModel assignment)
        {
            string username = SessionHelper.SessionHelper.Username;
            bool ans = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                string content = JsonConvert.SerializeObject(assignment);
                var response = await client.PostAsync($"TeacherAPI/AssignTask",new StringContent(content, Encoding.UTF8, "application/json"));
                
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    ans  = JsonConvert.DeserializeObject<bool>(responseData);
                }

                return ans;
            };
        }

        ///<summary> Set assignment Status
        public static async Task<bool> SetAssignmentStatus(int id)
        {
            bool ans = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                string content = JsonConvert.SerializeObject(id);
                var response = await client.PostAsync($"StudentAPI/SetAssignmentStatus?id={id}", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    ans = JsonConvert.DeserializeObject<bool>(responseData);
                }

                return ans;
            };
        }

        /// <summary> Return All task assigned Student Task List
        public static async Task<List<AssignmentModelList>> GetAllAssignedTask()
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/GetAllAssignedTask?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _taskList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _taskList;
        }
    }
}