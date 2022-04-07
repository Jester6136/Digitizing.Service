using System;
namespace Library.DataModel
{
    public partial class DropdownOptionModel
    {
        public string parent_id { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public int? sort_order { get; set; }
        public int? level { get; set; }
        public string label_e { get; set; }
        public string label_l { get; set; }
    }
   
}
