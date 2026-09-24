using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.TestData.Model
{
    public class DatePickerTDModel
    {
        public required string CategoryPage { get; set; }
        public required string Category { get; set; }
        public required int Day { get; set; }
        public required int Month { get; set; }
    }
}
