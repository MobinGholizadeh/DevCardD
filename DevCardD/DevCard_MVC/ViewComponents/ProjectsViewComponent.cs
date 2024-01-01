using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
	public class ProjectsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var projects = new List<Project>
			{
				new Project (  1,  "Taxi" ,  " IDK " , "project-1.jpg",  "Snapp"),
				new Project (  2,  "ZoodFood" ,  " IDK ZoodFood " ,  "project-2.jpg", "ZoodFood"),
				new Project (  3,  "Schools" ,  " Schools IDK " , "project-3.jpg", "MONOP"),
				new Project (  4,  "SpaceX" ,  " SpaceX IDK " ,"project-4.jpg",  "NASA"),
			};
			return View("_Projects" , projects);
		}
	}
}
