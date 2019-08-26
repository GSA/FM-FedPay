using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHpoNote
    {
        public string HponPoNo { get; set; }
        public decimal HponSeqNo { get; set; }
        public string HponNoteAddendums { get; set; }
        public string HponFssPoNo { get; set; }
        public string HponPoId { get; set; }
    }
}
