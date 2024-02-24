 using DevCard_MVC.Models;

namespace DevCard_MVC.Data
{
    public class ProjectStore
    {
       
        public static List<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project(  1,  "Taxi" ,  " Online taxi service " , "project-1.jpg",  "Snapp"),
                new Project(  2,  "ZoodFood" ,  " Online food ordering service " ,  "project-2.jpg", "ZoodFood"),
                new Project(  3,  "Schools" ,  " Schools service" , "project-3.jpg", "MONOP"),
                new Project(  4,  "SpaceX" ,  " SpaceX service" ,"project-4.jpg",  "NASA"),
            };
        }

        public static Project GetProjectBy(long id)
        {
            return GetProjects().FirstOrDefault(x => x.Id == id);
        }
    }
}
