using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasksprintbe.Models;
using tasksprintbe.Services;

namespace tasksprintbe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _data;

        public CommentController(CommentService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("AddComment")]
        public bool AddComment(CommentModel newComment)
        {
            return _data.AddComment(newComment);
        }

        [HttpGet]
        [Route("GetAllComments")]
        public IEnumerable<CommentModel> GetAllComments()
        {
            return _data.GetAllComments();
        }

        [HttpGet]
        [Route("GetCommentsByUsername")]
        public IEnumerable<CommentModel> GetCommentsByUsername(string username)
        {
            return _data.GetCommentsByUsername(username);
        }

        [HttpGet]
        [Route("GetCommentsByDescription")]
        public IEnumerable<CommentModel> GetCommentsByDescription(string description)
        {
            return _data.GetCommentsByDescription(description);
        }

        [HttpGet]
        [Route("GetCommentsByImage")]
        public IEnumerable<CommentModel> GetCommentsByImage(string image)
        {
            return _data.GetCommentsByUsername(image);
        }

        [HttpGet]
        [Route("GetCommentsByDate")]
        public IEnumerable<CommentModel> GetCommentsByDate(string date)
        {
            return _data.GetCommentsByUsername(date);
        }

        [HttpGet]
        [Route("GetCommentsByTime")]
        public IEnumerable<CommentModel> GetCommentsByTime(string time)
        {
            return _data.GetCommentsByUsername(time);
        }

        [HttpGet]
        [Route("GetCommentItemById/{id}")]
        public CommentModel GetCommentItemById(int id)
        {
            return _data.GetCommentItemById(id);
        }

        [HttpPut]
        [Route("UpdateCommentItem")]
        public bool UpdateCommentItem(CommentModel commentUpdate)
        {
            return _data.UpdateCommentItem(commentUpdate);
        }

        [HttpDelete]
        [Route("DeleteCommentItem")]
        public bool DeleteCommentItem(CommentModel commentToDelete)
        {
            return _data.DeleteCommentItem(commentToDelete);
        }
    }
}