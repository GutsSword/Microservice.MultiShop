﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Dtos.CatologDtos.CommentDto
{
    public class CreateCommendDto
    {
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
