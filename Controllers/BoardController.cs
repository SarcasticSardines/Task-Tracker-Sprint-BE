using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasksprintbe.Models;
using tasksprintbe.Models.DTO;
using tasksprintbe.Services;

namespace tasksprintbe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly BoardService _data;

        public BoardController(BoardService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("AddComment")]
        public bool AddBoard(BoardModel newBoard)
        {
            return _data.AddBoard(newBoard);
        }

        [HttpGet]
        [Route("GetAllBoards")]
        public IEnumerable<BoardModel> GetAllBoards()
        {
            return _data.GetAllBoards();
        }

        [HttpGet]
        [Route("GetBoardByBoardName")]
        public IEnumerable<BoardModel> GetBoardByBoardName(string name)
        {
            return _data.GetBoardByBoardName(name);
        }

        [HttpGet]
        [Route("GetBoardByInviteCode")]
        public IEnumerable<BoardModel> GetAllBoards(string code)
        {
            return _data.GetBoardByInviteCode(code);
        }

        [HttpGet]
        [Route("GetBoardByMemberList")]
        public IEnumerable<BoardModel> GetBoardByMemberList(string members)
        {
            return _data.GetBoardByMemberList(members);
        }

        [HttpGet]
        [Route("GetBoardByBoardId/{id}")]
        public BoardModel GetBoardById(int id)
        {
            return _data.GetBoardById(id);
        }

        [HttpPut]
        [Route("UpdateBoard")]
        public bool UpdateBoard(BoardModel boardUpdate)
        {
            return _data.UpdateBoard(boardUpdate);
        }

        [HttpDelete]
        [Route("BoardToDelete")]
        public bool BoardToDelete(BoardModel boardToUpdate)
        {
            return _data.BoardToDelete(boardToUpdate);
        }
    }
}