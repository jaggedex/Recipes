﻿using RecipesWebData;
using RecipeWebData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace RecipesWebApp.Models
{
    public class RecipeInputViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето със заглавие не може да бъде празно")]
        [StringLength(100, ErrorMessage = "Заглавието {0} трябва да бъде дълго между {2} у {1} символа.", MinimumLength = 4)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        [Display(Name = "Автор")]
        public string User { get; set; }

        [Required(ErrorMessage = "Трябва да изберете поне един продукт")]
        [Display(Name = "Необходими продукти")]
        public  List<SelectListItem> SelectProducts { get; set; }
        
        [Display(Name = "Необходими продукти")]
        public  ICollection<Product> Products { get; set; }

        
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Описанието не може да бъде празно!")]
        [StringLength(2000, ErrorMessage = "Описанието на рецептата трябва да съдържа поне 10 символа.", MinimumLength = 10)]
        [Display(Name = "Начин на приготвяне")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Типа на ястието не може да бъде празно")]
        [Display(Name = "Категория")]
        public string Type { get; set; }
        [Display(Name = "Добавена на")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Оценка")]
        public int Rating { get; set; }

        public string CurrentUserId { get; set; }

        public int OldRecipeId { get; set; }


        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public PaginationViewModel Pagination { get; set; }

        public string newProduct { get; set; }

        [Display(Name = "Снимка")]
        public byte[] Image { get; set; }

        public static Expression<Func<Recipe, RecipeInputViewModel>> ViewModel
        {
            get
            {
                return e => new RecipeInputViewModel()
                {
                    Id = e.ID,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                    Type = e.Type,
                    Products = e.Products,
                    AuthorId = e.AuthorId, 
                    Ratings = e.Ratings,
                    Comments = e.Comments,
                    Image = e.Image,
                    User = e.Author.UserName
                };
            }
        }

    }
}