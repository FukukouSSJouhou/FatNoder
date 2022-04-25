using FatNoder.Views;
using NodeNetworkJH.Toolkit.ValueNode;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels
{
    /// <summary>
    /// 数値を編集するNodeの基本形
    /// </summary>
    /// <typeparam name="T">編集対象の型</typeparam>
    public class HannyouValueEditorViewModel<T>:ValueEditorViewModel<T>
    {
        static HannyouValueEditorViewModel()
        {

            if (typeof(T) == typeof(string))
            {
                Splat.Locator.CurrentMutable.Register(() => new StringValueEditorView(), typeof(IViewFor<HannyouValueEditorViewModel<T>>));
            }
            else if(typeof(T) == typeof(int))
            {
                Splat.Locator.CurrentMutable.Register(() => new IntegerValueEditorView(), typeof(IViewFor<HannyouValueEditorViewModel<T>>));

            }

        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
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
