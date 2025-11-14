
using P03.DetailPrinter;
using System;
using System.Collections.Generic;

namespace P03.Detail_Printer
{
    public class CEO : Manager
    {
        private string financeInfo;
        public CEO(string name, ICollection<string> documents, string financeInfo) 
            : base(name, documents)
        {
            this.financeInfo = financeInfo;
        }

        public override string GetDetails()
        {
            return string.Join("|", base.GetDetails(), financeInfo);
        }
    }
}
