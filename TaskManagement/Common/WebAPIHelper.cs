using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Common
{
    public class WebAPIHelper
    {
        public static string ApiUrl = "http://localhost:63373/api/";
        public static async Task<List<AssignmentModelList>> CompletedStudentList()
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/AList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _assignmentList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            }; 
            return _assignmentList;
        }

        public static async Task<List<AssignmentModelList>> PendingStudentList()
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/GetPendingTaskStudentList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _assignmentList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _assignmentList;
        }

        public static async Task<List<AssignmentModelList>> GetAllTaskAssignedStudentList()
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            int id = SessionHelper.SessionHelper.UserId;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var response = await client.GetAsync($"StudentAPI/GetAllTaskAssignedStudentList?Id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    _taskList = JsonConvert.DeserializeObject<List<AssignmentModelList>>(responseData);
                }
            };
            return _taskList;
        }        
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


    }
}