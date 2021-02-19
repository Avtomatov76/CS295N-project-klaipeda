using System;
using System.Collections.Generic;
using System.Linq;
using KlaipedaCity.Models;
using System.Threading.Tasks;

namespace KlaipedaCity.Repos
{
    public interface IForumPost
    {
        IQueryable<ForumPost> ForumPosts { get; } // Read or retrieve
        void AddForumPost(ForumPost post); // Create a ForumPost entity
        ForumPost GetForumPostBySubject(string subject); // Retrieve a post by its subject
        void UpdateForumPost(ForumPost post); // Updates a forum post in the database (add comments)
    }
}
