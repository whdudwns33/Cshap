using Cs_pr01.Model;
using Cs_pr01.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cs_pr01.Controller
{
    public class PostController
    {
        private BoardContext db = new BoardContext();

        public List<Post> GetPosts()
        {
            return db.GetAllPosts();
        }

        public void AddPost(Post post)
        {
            db.AddPost(post);
        }
    }
}

