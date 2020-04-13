using fitnessMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace fitnessMVC
{
    public class ModelList
    {
        public List<tbl_corusel> corusels { get; set; }
        public List<tbl_trend> trends { get; set; }
        public List<tbl_slider> slider { get; set; }
        public List<tbl_color3> color3s { get; set; }
        [AllowHtml]
        public List<tbl_mainPost> mainPosts { get; set; }
        public tbl_mainPost mainPostSingle { get; set; }
        public List<tbl_parallax> parallax { get; set; }
        public List<tbl_mansoryPhoto> mansoryPhotos { get; set; }
        public tbl_parallax2 Parallax2 { get; set; }
        public List<tbl_companyName> companyNames { get; set; }
        public List<tbl_link> links { get; set; }
        public List<tbl_contact> contacts { get; set; }
        public tbl_admin admin { get; set; }

    }
}