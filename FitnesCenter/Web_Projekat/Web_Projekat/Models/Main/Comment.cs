using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Projekat.Models
{
    public class Comment
    {
        User visitor;
        int fitnessCenterId;
        string text;
        int mark;
        bool validate;
        int commentId;

        public Comment()
        {

        }

        public Comment(bool validate, User visitor, int fitnessCenterId, string text, int mark)
        {
            this.Validate = validate;
            this.visitor = visitor;
            this.fitnessCenterId = fitnessCenterId;
            this.text = text;
            this.mark = mark;
            this.commentId = XMLWorker.GenerateCommentId();
        }

        public User Visitor { get => visitor; set => visitor = value; }
        public int FitnessCenterId { get => fitnessCenterId; set => fitnessCenterId = value; }
        public string Text { get => text; set => text = value; }
        public int Mark { get => mark; set => mark = value; }
        public bool Validate { get => validate; set => validate = value; }
        public int CommentId { get => commentId; set => commentId = value; }
    }
}