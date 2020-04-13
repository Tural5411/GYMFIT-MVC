namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_link
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Header { get; set; }
    }
}
