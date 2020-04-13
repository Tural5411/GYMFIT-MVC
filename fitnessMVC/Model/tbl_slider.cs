namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_slider
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Header { get; set; }

        [StringLength(80)]
        public string Description { get; set; }

        [StringLength(600)]
        public string Photo { get; set; }
    }
}