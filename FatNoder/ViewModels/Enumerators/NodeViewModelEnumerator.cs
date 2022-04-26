using DynamicData;
using FatNoder.Model.Transc;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Enumerators
{
    public class NodeViewModelEnumerator : IEnumerator
    {
        private NodeViewModel _currentNVM;
        private NodeViewModel _RootNVM;
        private IEnumerable<NodeViewModel> _nodes;
        public object Current
        {
            get
            {
                return _currentNVM;
            }
        }

        public bool MoveNext()
        {
            if (_currentNVM == null)
            {
                _currentNVM = _RootNVM;
                return true;
            }else
            {

                foreach (NodeInputViewModel nvi in _currentNVM.Inputs.Items)
                {
                    if (nvi.Name == "Out")
                    {
                        dynamic dyi = nvi;

                        if (dyi is ValueListNodeInputViewModel<StatementCls>)
                        {
                            IObservableList<StatementCls> valueskun;

                            valueskun = dyi.Values as IObservableList<StatementCls>;

                            foreach (StatementCls s in valueskun.Items)
                            {
                                foreach (NodeViewModel n in _nodes)
                                {
                                    if (n.UUID == s.UUID)
                                    {
                                        _currentNVM = n;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
        }

        public void Reset()
        {
            _currentNVM = null;
        }
    }
}
