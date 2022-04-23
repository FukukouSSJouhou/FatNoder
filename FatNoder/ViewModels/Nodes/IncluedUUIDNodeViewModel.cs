using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class IncluedUUIDNodeViewModel:NodeViewModel
    {

        static IncluedUUIDNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<IncluedUUIDNodeViewModel>));
        }
        public Guid UUID { get; }
        public IncluedUUIDNodeViewModel()
        {
            UUID = Guid.NewGuid();
        }
        public IncluedUUIDNodeViewModel(Guid uUID)
        {
            UUID = uUID;
        }

    }
}
