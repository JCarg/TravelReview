﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelReviewProject.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
    }
}