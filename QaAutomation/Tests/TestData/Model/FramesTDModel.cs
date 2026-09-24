using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.TestData.Model
{
    public class FramesTDModel
    {
        public required string CategoryPage { get; set; } 
        public required string Category { get; set; } 
        public required string NextCategory { get; set; } 
        public required string ParentFrameText { get; set; } 
        public required string ChildFrameText { get; set; } 
    }
}
