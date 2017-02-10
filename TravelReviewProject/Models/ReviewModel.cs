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
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime VacationStart { get; set; }
        public DateTime VacationEnd { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}