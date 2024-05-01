using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasksprintbe.Services;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _data;
        public MemberController(MemberService data){
            _data = data;
        }

        [HttpGet]
        [Route("UserBoards/{userId}")]
        public IActionResult UserBoards(int userId){
            return _data.UserBoards(userId);
        }

        [HttpGet]
        [Route("BoardMembers/{boardId}")]
        public IActionResult BoardMembers(int boardId){
            return _data.BoardMembers(boardId);
        }

        [HttpPost]
        [Route("AddBoardToMember")]
        public async Task<IActionResult> AddBoardToMember(int userId, int boardId){
            return await _data.AddBoardToMember(userId, boardId);
        }

        [HttpPost]
        [Route("AddMemberToBoard")]
        public async Task<IActionResult> AddMemberToBoard(int userId, int boardId){
            return await _data.AddMemberToBoard(userId, boardId);
        }

        [HttpDelete]
        [Route("RemoveMemberFromBoard")]
        public async Task<IActionResult> RemoveMemberFromBoard(int userId, int boardId){
            return await _data.RemoveMemberFromBoard(userId, boardId);
        }
        
        [HttpDelete]
        [Route("RemoveBoardFromUser")]
        public async Task<IActionResult> RemoveBoardFromUser(int userId, int boardId){
            return await _data.RemoveBoardFromUser(userId, boardId);
        }
    }
}