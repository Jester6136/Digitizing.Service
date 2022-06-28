using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class TeacherProjectModel
	{
        public Guid teacher_pro_id { get; set; }
        public int quantity { get; set; }
        public string teacher_id_rcd { get; set; }
        public string teacher_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string additional_information { get; set; }
        public int? project_register_status { get; set; }
        public bool available_to_register { get; set; }
    }
}