using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While_E.Models
{
    class WebServiceHelpers
    {
        public static List<Users> GetUsers()
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_User();
            List<Users> UserList = new List<Users>();

            foreach(var item in response)
            {
                Users user = new Users();

                user.userID = (int)item.userID;
                user.userName = item.userName.ToString();
                user.userRole = item.userRole.ToString();
                UserList.Add(user);
            }
            return UserList;
        }

        public static List<Task> GetTask()
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_Task();
            List<Task> TaskList = new List<Task>();

            foreach(var item in response)
            {
                Task task = new Task();

                task.taskId = (int)item.taskId;
                task.taskName = item.taskName.ToString();
                task.taskDesc = item.taskDesc.ToString();
                task.taskComplete = (bool)item.taskComplete;
                task.userID = (int)item.userID;
                TaskList.Add(task);
            }
            return TaskList;
        }

        public static void Add_User(string name, string role)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Add_User(name, role);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
            
        }

        public static void Del_User(int ID)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Del_User(ID);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
        }

        public static void Update_User(int ID, string name, string role)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Update_User(ID, name, role);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
            
        }

        public static void Add_Task(string name, string desc, bool comp, int userID)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Add_Task(name, desc, comp, userID);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
        }
        public static void Del_Task(int ID)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Del_Task(ID);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
        }
        public static void Update_Task(int ID, bool comp)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            try
            {
                service.Update_Task(ID, comp);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
        }
        public static List<Users> GetSelectedUser(string name)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_Selected_User(name);
            List<Users> SelectedUser = new List<Users>();

            foreach (var item in response)
            {
                Users user = new Users();

                user.userID = (int)item.userID;
                user.userName = item.userName.ToString();
                user.userRole = item.userRole.ToString();
                SelectedUser.Add(user);
            }
            return SelectedUser;
        }
        public static List<Task> GetSelectedTask(int ID)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_Selected_Task(ID);
            List<Task> selectedTask = new List<Task>();

            foreach (var item in response)
            {
                Task task = new Task();

                task.taskId = (int)item.taskId;
                task.taskName = item.taskName.ToString();
                task.taskDesc = item.taskDesc.ToString();
                task.taskComplete = (bool)item.taskComplete;
                task.userID = (int)item.userID;

                selectedTask.Add(task);
            }
            return selectedTask;
        }
        public static List<Users> GetUserName(string name)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_UserName(name);
            List<Users> SelectedUser = new List<Users>();


            foreach (var item in response)
            {
                Users user = new Users();

                user.userID = (int)item.userID;
                SelectedUser.Add(user);
            }
            return SelectedUser;
        }
        public static List<Task> GetCompTask(int ID)
        {
            Service.ServiceSoapClient service = new Service.ServiceSoapClient();
            var response = service.Get_CompTasks(ID);
            List<Task> compTasks = new List<Task>();

            foreach (var item in response)
            {
                Task task = new Task();

                task.taskId = (int)item.taskId;
                task.taskName = item.taskName.ToString();
                task.taskDesc = item.taskDesc.ToString();
                task.taskComplete = (bool)item.taskComplete;
                task.userID = (int)item.userID;

                compTasks.Add(task);
            }

            return compTasks;
        }

    }
    
}
