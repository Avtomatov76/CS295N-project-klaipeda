using System;
using Microsoft.EntityFrameworkCore;
using KlaipedaCity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Repos
{
    public class ForumPostRepository : IForumPost
    {
        private KlaipedaDbContext context;

        // constructor
        public ForumPostRepository(KlaipedaDbContext c)
        {
            context = c;
        }

        public IQueryable<ForumPost> ForumPosts
        {
            get
            {
                // Get all ForumPost objects in the ForumPost DbSet
                // and include CommentAuthor object and list of comments for each ForumPost.
                return context.ForumPosts.Include(post => post.Sender)
                        .Include(post => post.Comments)
                        .ThenInclude(comment => comment.CommentAuthor);
            }
        }

        public void AddForumPost(ForumPost post)
        {
            context.ForumPosts.Add(post);
            context.SaveChanges();
        }

        public ForumPost GetForumPostBySubject(string subject)
        {
            return  context.ForumPosts.Find(subject);
        }

        public void UpdateForumPost(ForumPost post)
        {
            context.ForumPosts.Update(post);
            context.SaveChanges();
        }
    }
}
