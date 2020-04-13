namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_contact
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }
    }
}
