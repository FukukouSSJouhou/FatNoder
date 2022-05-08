using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyanoVMLibs.ViewModels.Nodes
{
    public partial class NodeVMBasekun
    {
        private void InitNodeVM()
        {

            NameChanged = this.WhenAnyValue(vm => vm.Name);
            PositionChanged = this.WhenAnyValue(vm => vm.Position);
            UUIDChanged = this.WhenAnyValue(vm => vm.UUID);
        }
    }
}
