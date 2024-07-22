﻿using MultiShop.WebUI.Dtos.CatologDtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Dtos.CatologDtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal PreviousProductPrice { get; set; }

        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        public CategoryListDto Category { get; set; }
    }
}
