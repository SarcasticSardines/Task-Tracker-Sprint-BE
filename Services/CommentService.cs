using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksprintbe.Models;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Services
{
    public class CommentService
    {

        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }

        public bool AddComment(CommentModel newTaskItem)
        {
            _context.Add(newTaskItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<CommentModel> GetAllComments()
        {
            return _context.CommentInfo;
        }

        public IEnumerable<CommentModel> GetCommentsById(int id)
        {
            return _context.CommentInfo.Where(item => item.ID == id);
        }

        public IEnumerable<CommentModel> GetCommentsByUsername(string username)
        {
            return _context.CommentInfo.Where(item => item.Username == username);
        }

        public IEnumerable<CommentModel> GetCommentsByDescription(string description)
        {
            return _context.CommentInfo.Where(item => item.Description == description);
        }

        public IEnumerable<CommentModel> GetCommentsByDate(string date)
        {
            return _context.CommentInfo.Where(item => item.Date == date);
        }

        public IEnumerable<CommentModel> GetCommentsByTime(string time)
        {
            return _context.CommentInfo.Where(item => item.Time == time);
        }

        public CommentModel GetCommentItemById(int id)
        {
            return _context.CommentInfo.SingleOrDefault(item => item.ID == id);
        }

        public bool UpdateCommentItem(CommentModel commentUpdate)
        {
            _context.Update<CommentModel>(commentUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool DeleteCommentItem(CommentModel commentToDelete)
        {
            commentToDelete.IsDeleted = true;
            _context.Update<CommentModel>(commentToDelete);
            return _context.SaveChanges() != 0;
        }
    }
}