namespace fitnessMVC.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_corusel
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Header { get; set; }

        public string Context { get; set; }

        [StringLength(600)]
        public string Photo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PostTime { get; set; }

        public virtual tbl_post_category tbl_post_category { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
