using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.TestData.Model
{
    public class AlertsTDModel
    {
        public required string CategoryPage { get; set; }
        public required string Category { get; set; }
        public required string AlertText { get; set; }
        public required string ConfirmText { get; set; }
        public required string ConfirmResult { get; set; }
        public required string PromptText { get; set; }
    }
}
