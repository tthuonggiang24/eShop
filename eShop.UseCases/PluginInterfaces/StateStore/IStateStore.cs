using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListener(Action listeners);
        void RemoveStateChangeListener(Action listeners);
        void BroadcastStateChange();
    }
}
