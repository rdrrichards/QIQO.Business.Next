﻿using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
{
    public class CommentEntityService : ICommentEntityService
    {
        public Comment Map(CommentData commentData) => new Comment(commentData);
        public CommentData Map(Comment comment) => new CommentData()
        {
            CommentKey = comment.CommentKey,
            CommentTypeKey = (int)comment.CommentType,
            CommentValue = comment.CommentValue,
            EntityKey = comment.EntityKey,
            EntityType = comment.EntityTypeKey
        };
    }
}
