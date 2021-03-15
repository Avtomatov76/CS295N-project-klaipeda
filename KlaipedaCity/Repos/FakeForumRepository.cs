using System;
using System.Collections.Generic;
using System.Linq;
using KlaipedaCity.Models;
using System.Threading.Tasks;

namespace KlaipedaCity.Repos
{
    public class FakeForumRepository : IForumPost
    {
        private List<ForumPost> posts = new List<ForumPost>();

        public IQueryable<ForumPost> ForumPosts { get { return posts.AsQueryable<ForumPost>(); } }

        public void AddForumPost(ForumPost post)
        {
            post.ForumPostID = posts.Count;
            posts.Add(post);
        }

        public ForumPost GetForumPostBySubject(string subject)
        {
            return posts.Find(p => p.Subject == subject);
        }

        public void UpdateForumPost(ForumPost post)
        {
            var comment = new Comment()
            {
                CommentID = 1,
                CommentAuthor = new AppUser { SenderName = "Bill Clinton" },
                CommentBody = "This is a TEST!!!",
                CommentDate = DateTime.Today
            };

            post.Comments.Add(comment);
        }
    }
}
