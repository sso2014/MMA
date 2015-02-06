using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace DataV2
{
    interface IRepositoryState
    {
        List<State> SelectedStateAll();
        State SelectedByState(int id);
        void InsertState(State state);
        void UpdateState(State state);
        void DeleteState(State state);
    }
}
