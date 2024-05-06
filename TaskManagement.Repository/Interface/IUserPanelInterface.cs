using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface
{
    public interface IUserPanelInterface
    {
        //login interface
        bool Login(SignupCustomModel login);


        //Signup interface 
        bool Signup(SignupCustomModel user);
    }
}
