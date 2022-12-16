using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Mocks;
using MyBlogInitiation.Models;
//using MyBlogInitiation.Repository.Context;
//using MyBlogInitiation.Repository.Context;
using MyBlogInitiation.Repository.DAL;
//using MyBlogInitiation.ViewModels;

namespace MyBlogInitiation.Controllers
{

    /** refactoring:
      Creer la Dal dans le projet repository
      Parametrer l'injection dans programcs (addtranscient)
      injecter la dal ici dans le constructeur
      Enlever toutes les occurences ici a _context ,en les remplacant par des appels au repo
    */


    public class ArticlesController : Controller
        {

       // private readonly DbBlogContext _dbBlogContext;
        private readonly ArticlesPublicDAL _articlesPublicDAL;


        //public ArticlesController(DbBlogContext dbBlogContext)
        public ArticlesController(ArticlesPublicDAL articlesPublicDAL)
        {
            //_dbBlogContext= dbBlogContext;
            _articlesPublicDAL = articlesPublicDAL;
        }
            
        public async Task <IActionResult> Index()
        {
            var vm = new ArticlesViewModel
            {
                //Articles = await _dbBlogContext.Articles.ToListAsync();
                Articles = await _articlesPublicDAL.GetAllArticles()
            };
            return View(vm);
        }


     /* -----------  Deplacé dans dev Options controller
      *   public async Task <IActionResult> AddDataFromMock()
        {
            var lstArticleMock = ArticlesMock.listArticles;
            // on ajoute les articles Mock
            // _dbBlogContext.Articles.AddRange(ArticlesMock.listArticles);
            _articlesPublicDAL.Articles.AddRange(ArticlesMock.listArticles);
            // on sauvegarde 
            await _dbBlogContext.SaveChangesAsync();
            //  
            return RedirectToAction("Index");
     }-----------------*/

        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _dbBlogContext.Articles == null)

            if (id == null)
            {
                return NotFound();
            }
            //var articleModel = await _dbBlogContext.Articles.FirstOrDefaultAsync(article => article.Id == id);
            var articleModel =await _articlesPublicDAL.GetArticle(id.Value);
          
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
