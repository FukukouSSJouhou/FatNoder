using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Enumerator
{
    public class NodeModelEnumerator : IEnumerator<XML_NodeModel>
    {
        private XML_NodeModel _Current;
        private XML_NodeModel _root;
        private IEnumerable<XML_NodeModel> _nodes;
        public XML_NodeModel Current
        {
            get
            {
                return _Current;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {

            if (_Current == null)
            {
                _Current = _root;
                return true;
            }
            else
            {
                foreach(XMLNodeInputStatement xns in _Current.InputStates.Where(d =>
                {
                    return d.Name == "Out";
                }))
                {
                    foreach(Guid uuidkun in xns.States)
                    {
                        foreach(XML_NodeModel nm in _nodes.Where(d =>
                        {
                            return d.UUID == uuidkun;
                        }))
                        {
                            _Current = nm;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Reset()
        {
            _Current = null;
        }
    }
}
