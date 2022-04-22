using FatNoder.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels
{
    public class HannyouValueEditorViewModel<T>:ValueEditorViewModel<T>
    {
        static HannyouValueEditorViewModel()
        {

            if (typeof(T) == typeof(string))
            {
                Splat.Locator.CurrentMutable.Register(() => new StringValueEditorView(), typeof(IViewFor<HannyouValueEditorViewModel<T>>));
            }

        }
        public HannyouValueEditorViewModel()
        {
            object ret = null;
            if (typeof(T) == typeof(string))
            {
                ret = "";
            }
            else if(typeof(T)==typeof(int))
            {
                ret = 0;
            }else if (typeof(T) == typeof(long))
            {
                ret = 0;
            }
            else
            {
                ret = null;
            }
            Value=(T)ret;
        }
    }
}
