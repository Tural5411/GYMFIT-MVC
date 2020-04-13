namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mansoryPhoto
    {
        public int Id { get; set; }

        [StringLength(600)]
        public string longphoto { get; set; }

        [StringLength(600)]
        public string normalPhoto { get; set; }

        [StringLength(50)]
        public string Header { get; set; }
    }
}
