using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelReviewProject.Models
{
    public class ReviewModel
    {
        [Key]
        public int ID { get; set; }

        public string Summary { get; set; }
        [Display(Name ="Vacation Title")]
        public string Title { get; set; }
        [Display(Name ="Experience")]
        public string Comment { get; set; }
        public string Location { get; set; }
        [Display(Name="Publish Date")]
        public DateTime PublishDate { get; set; }
        [Display(Name ="Vacation Start Date")]
        public DateTime VacationStart { get; set; }
        [Display(Name = "Vacation End Date")]
        public DateTime VacationEnd { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}