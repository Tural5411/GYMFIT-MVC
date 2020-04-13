using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fitnessMVC.Model
{
    [Table("Comment")]
    public class comment
    {
        public int CommentId { get; set; }
        [Required,StringLength(50,ErrorMessage ="50 KARAKTER OLA BILER !")]
        public string Adsoyad { get; set; }
        public string Email { get; set; }
        [DisplayName("Serhiniz")]
        public string context { get; set; }
        public int? PostId { get; set; }
        public tbl_mainPost Post { get; set; }
    }
}