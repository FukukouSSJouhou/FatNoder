using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Model.Transc
{
    public class StatementCls
    {
        public Guid UUID { get; set; }
        public static StatementCls GenStatementCls(Guid uUID)
        {
            return new StatementCls(uUID);
        }
        public static StatementCls GenStatementCls()
        {
            return new StatementCls();
        }
        public StatementCls(Guid uUID)
        {
            UUID = uUID;
        }
        public StatementCls() : this(Guid.NewGuid())
        {

        }
    }
}
