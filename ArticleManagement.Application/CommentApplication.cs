﻿using ArticleManagement.Application.Contracts.Comment;
using ArticleManagement.Domain.CommentAgg;

namespace ArticleManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.CreateAndSaveComment(comment);
        }
    }
}