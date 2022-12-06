using Microsoft.AspNetCore.Mvc;
using MyBlogInitiation.Mocks;
using MyBlogInitiation.Repository.Context;
using MyBlogInitiation.Repository.DAL;

namespace MyBlogInitiation.Controllers
{
    public class DevOptionsController : Controller


    {


        private readonly DbBlogContext _dbBlogContext;
        //private readonly ArticlesPublicDAL _articlesPublicDAL;


        public DevOptionsController(DbBlogContext dbBlogContext)
        //public ArticlesController(ArticlesPublicDAL articlesPublicDAL)
        {
            _dbBlogContext= dbBlogContext;
           // _articlesPublicDAL = articlesPublicDAL;
        }


        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> AddDataFromMock()
        {
            var lstArticleMock = ArticlesMock.listArticles;
            // on ajoute les articles Mock
            
             _dbBlogContext.Articles.AddRange(ArticlesMock.listArticles);
            //_articlesPublicDAL.Articles.AddRange(ArticlesMock.listArticles);
            // on sauvegarde 
            await _dbBlogContext.SaveChangesAsync();
            //  
            return RedirectToAction("Index");
        }









    }
}
