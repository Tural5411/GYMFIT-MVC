namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_tag
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string tagName { get; set; }
    }
}
