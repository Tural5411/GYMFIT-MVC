namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_color3
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string Header { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
