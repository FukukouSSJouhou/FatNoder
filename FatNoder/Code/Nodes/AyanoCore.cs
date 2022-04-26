using FatNoder.ViewModels.Enumerators;
using FatNoder.ViewModels.Nodes;
using NodeNetworkJH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Code.Nodes
{
    /// <summary>
    /// This is a transcompiler.
    /// </summary>
    public class AyanoCore
    {
        private IEnumerable<NodeViewModel> _Nodes;
        public IEnumerable<NodeViewModel> Nodes
        {
            get
            {
                return _Nodes;
            }
            set
            {
                _Nodes = value;
            }
        }
        private string _namespaceid;
        public string NamespaceID
        {
            get
            {
                return _namespaceid;
            }
            set
            {
                _namespaceid = value;
            }
        }
        public string clsname
        {
            get;set;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="novms">Nodes</param>
        public AyanoCore(IEnumerable<NodeViewModel> novms)
        {
            _Nodes = novms;
        }
        public string Compile()
        {
            string returnstr = "";
            List<string> usinglist = new List<string>();
            usinglist.Add("System");
            foreach(string n in usinglist)
            {
                returnstr += $"using {n};\n";
            }
            returnstr += $"namespace {_namespaceid} " + "{\n";
            returnstr += $"\tpublic class {clsname} " + "{\n";
            //class syori
            foreach(NodeViewModel n in _Nodes)
            {
                if(n is MethodEntryPointVIewModel)
                {
                    //start!
                    NodeViewModelEnumerator iterator = new NodeViewModelEnumerator(n, _Nodes);
                    while (iterator.MoveNext())
                    {
                        NodeViewModel nvm = (NodeViewModel)iterator.Current;
                        Console.WriteLine(nvm.GetType().ToString());
                        Console.WriteLine(nvm.UUID);
                    }
                }
            }
            returnstr += "}";
            returnstr += "}";
            return returnstr;
        }
    }
}
