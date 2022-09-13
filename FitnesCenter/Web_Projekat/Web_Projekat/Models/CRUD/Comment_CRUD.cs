using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class Comment_CRUD
    {
        public static List<Comment> GetAllComments()
        {
            List<Comment> comments = (List<Comment>)HttpContext.Current.Application["comments"];
            return comments;
        }

        public static void AddComment(Comment c)
        {
            List<Comment> comments = (List<Comment>)HttpContext.Current.Application["comments"];
            XMLWorker.AddComment(c);
            HttpContext.Current.Application["comments"] = XMLWorker.LoadAllComments();
        }

        public static void RemoveComment(Comment c)
        {
            List<Comment> comments = (List<Comment>)HttpContext.Current.Application["comments"];
            comments.Remove(c);
            XMLWorker.UpdateComment(comments);
            HttpContext.Current.Application["comments"] = XMLWorker.LoadAllComments();
        }
    }
}