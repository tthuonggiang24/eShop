using eShop.UseCases.PluginInterfaces.StateStore;
using System.Runtime.CompilerServices;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        private Action listeners;
        public void AddStateChangeListener(Action listeners) => this.listeners += listeners;
        public void RemoveStateChangeListener(Action listeners) => this.listeners -= listeners;
        //this.listeners = this.listeners + listeners;
        public void BroadcastStateChange()
        {
            if(this.listeners != null)
            {
                this.listeners.Invoke();
            }
        }
    }
}
