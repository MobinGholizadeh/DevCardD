using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
	public class LatestArticlesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var articles = new List<Article>
			{
				new Article( 1 , "Learning ASP.net core MVC" , "No Idea" ,"blog-post-thumb-card-1.jpg" ),
				new Article( 2 , "Learning ASP.net core MVC" , "No Idea" ,"blog-post-thumb-card-2.jpg" ),
				new Article( 3 , "Learning ASP.net core MVC" , "No Idea" ,"blog-post-thumb-card-3.jpg" ),
				new Article( 4 , "Learning ASP.net core MVC" , "No Idea" ,"blog-post-thumb-card-4.jpg" )
			};
			return View("_LatestArticles" , articles);
		}
	}
}
