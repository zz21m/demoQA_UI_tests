using System;
using System.Collections.Generic;
using System.Text;
using Tests.TestData.Model;

namespace Tests.TestData
{
    public class TestDataModel
    {
        public required AlertsTDModel Alerts { get; set; }
        public required FramesTDModel Frames { get; set; }
        public required List<TablesTDModel> Tables { get; set; }
        public required HandlesTDModel Handles { get; set; }
        public required SliderProgressBarTDModel SliderProgressBar { get; set; }
        public required DatePickerTDModel DatePicker { get; set; }
        public required FilesTDModel Files { get; set; }
    }
}
