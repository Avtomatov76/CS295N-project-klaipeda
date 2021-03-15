using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using KlaipedaCity.Models;
using KlaipedaCity.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KlaipedaCity.Controllers
{
    public class ForumController : Controller
    {
        IForumPost repo;
        UserManager<AppUser> userManager;

        public ForumController(IForumPost r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }

        [Authorize] 
        public IActionResult Index()
        {
            // get all the messages from the database
            List<ForumPost> posts = repo.ForumPosts.ToList<ForumPost>();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(ForumPost model) //CHECK IT
        {
            // Pulling the current user obj from the DB and use it as Sender obj
            model.Sender = userManager.GetUserAsync(User).Result; // .Result IS short-circutting async methods (a little trick) 1111111111111111111111111111
            // TODO: get the user's real name in registration
            model.Sender.SenderName = model.Sender.UserName; // temporary hack
            model.DateSent = DateTime.Now;
            // Store the model in the database if ModelState is valid
            if (ModelState.IsValid)
            {
                repo.AddForumPost(model);
            }
            else
            {
                return View(model);
            }
            return Redirect("Index"); // displays all posts
        }

        // Returns a search-by-subject or by 'SentDate' result(s)
        [HttpPost]
        public IActionResult Index(string subject, string DateSent)
        {
            List<ForumPost> posts = null;

            if (subject != null)
            {
                posts = (from p in repo.ForumPosts
                         where p.Subject.ToLower().Contains(subject)
                         select p).ToList();
            }
            else if (DateSent != null)
            {
                DateTime date;
                DateTime.TryParse(DateSent, out date); // parsing a string into a DateTime obj

                posts = (
                    from p in repo.ForumPosts
                    where p.DateSent.Date.Month == date.Month
                    && p.DateSent.Date.Day == date.Day
                    && p.DateSent.Date.Year == date.Year
                    select p).ToList();
            }
            else
                return RedirectToAction("Index"); 

            return View(posts);
        }

        [Authorize]
        public IActionResult Comment(int postId)
        {
            var commentVM = new CommentVM { ForumPostID = postId };
            return View(commentVM);
        }

        [HttpPost]
        public RedirectToActionResult Comment(CommentVM commentVM) 
        {
            // Comment is the domain model
            var comment = new Comment { CommentBody = commentVM.CommentBody };
            comment.CommentAuthor = userManager.GetUserAsync(User).Result; // .Result IS short-circutting async methods (a little trick) 11111111111111111111
            //reply.ReplyAuthor.SenderName = reply.ReplyAuthor.UserName; // temporary hack
            comment.CommentDate = DateTime.Now;

            // Retrieve the post this comment is for
            var post = (from p in repo.ForumPosts
                           where p.ForumPostID == commentVM.ForumPostID
                           select p).First<ForumPost>();

            post.Comments.Add(comment);
            repo.UpdateForumPost(post);

            return RedirectToAction("Index");
        }

    }
}
