﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Mocks;
using MyBlogInitiation.Models;
using MyBlogInitiation.Repository.Context;
using MyBlogInitiation.ViewModels;

namespace MyBlogInitiation.Controllers
{
    public class ArticlesController : Controller
        {

        private readonly DbBlogContext _dbBlogContext;
        public ArticlesController(DbBlogContext dbBlogContext)
        {
            _dbBlogContext= dbBlogContext;
        }
            
        public async Task <IActionResult> Index()
        {
               var vm = new ArticlesViewModel
            {
               // creer une liste d'articles en dur ://Articles = ArticlesMock.listArticles
               Articles= await _dbBlogContext.Articles.ToListAsync()
            };
            return View(vm);
        }


        public async Task <IActionResult> AddDataFromMock()
        {
            var lstArticleMock = ArticlesMock.listArticles;
            // on ajoute les articles Mock
            // _dbBlogContext.Articles.AddRange(ArticlesMock.listArticles);
            _dbBlogContext.Articles.AddRange(ArticlesMock.listArticles);
            // on sauvegarde 
            await _dbBlogContext.SaveChangesAsync();
            //  
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbBlogContext.Articles == null)
            {
                return NotFound();
            }

            var articleModel =await _dbBlogContext.Articles.FirstOrDefaultAsync(article =>article.Id==id);
          
            if (articleModel == null || !articleModel.Available)
            {
                return NotFound();
            }

            return View(articleModel);
        }




        public IActionResult Stock()
        {
            return View();
        }
    }
}
