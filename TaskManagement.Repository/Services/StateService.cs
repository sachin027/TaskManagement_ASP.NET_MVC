using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.StateHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class StateServices : IStateInterface
    {
        private readonly TaskManagement_452Entities _DBContext;

        public StateServices()
        {
            _DBContext = new TaskManagement_452Entities();
        }

        public List<StateModel> StateModelList()
        {
            List<StateModel> stateModelList = new List<StateModel>();
            List<States> states = _DBContext.States.ToList();

            stateModelList = StateHelper.ConvertStateToStateModel(states);
            return stateModelList;
        }
    }
}
