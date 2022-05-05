using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Model.Transc
{
    /// <summary>
    /// Statement CLS???
    /// </summary>
    public class StatementCls
    {
        public Guid UUID { get; set; }
        /// <summary>
        /// get new statement
        /// </summary>
        /// <param name="uUID">uuid</param>
        /// <returns>New Statement</returns>
        public static StatementCls GenStatementCls(Guid uUID)
        {
            return new StatementCls(uUID);
        }
        /// <summary>
        /// Gen New Statement
        /// </summary>
        /// <returns>New Statement</returns>
        public static StatementCls GenStatementCls()
        {
            return new StatementCls();
        }
        /// <summary>
        /// Constructor UUID
        /// </summary>
        /// <param name="uUID">UUID</param>
        public StatementCls(Guid uUID)
        {
            UUID = uUID;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public StatementCls() : this(Guid.NewGuid())
        {

        }
    }
}
