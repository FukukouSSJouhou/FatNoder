using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Enumerator
{
    /// <summary>
    /// NodeModelのEnumerator!
    /// </summary>
    public class NodeModelEnumerator : IEnumerator<XML_NodeModel>
    {
        private XML_NodeModel _Current;
        private XML_NodeModel _root;
        private IEnumerable<XML_NodeModel> _nodes;
        /// <summary>
        /// 現在の要素を取得
        /// </summary>
        public XML_NodeModel Current
        {
            get
            {
                return _Current;
            }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="root">root要素</param>
        /// <param name="nodes">nodeたち</param>
        public NodeModelEnumerator(XML_NodeModel root, IEnumerable<XML_NodeModel> nodes)
        {
            _Current = null;
            _root = root;
            _nodes = nodes;
        }

        object IEnumerator.Current => throw new NotImplementedException();

        /// <inheritdoc/>
        public void Dispose()
        {

        }
        /// <summary>
        /// イテレータを次に進める
        /// </summary>
        /// <returns>成功したか否か</returns>
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
        /// <summary>
        /// リセット
        /// </summary>
        public void Reset()
        {
            _Current = null;
        }
    }
}
