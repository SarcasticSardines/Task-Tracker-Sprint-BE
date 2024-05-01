using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasksprintbe.Models;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Services
{
    public class MemberService : ControllerBase
    {
        private readonly DataContext _context;
        public MemberService(DataContext context){
            _context = context;
        }

        public IActionResult UserBoards(int userId){
            var boardIds = _context.MemberInfo
            .Where(bm => bm.UserID == userId)
            .Select(bm => bm.BoardID)
            .ToList();
            return Ok(boardIds);
        }

        public IActionResult BoardMembers(int boardId){
            var memberIds = _context.MemberInfo
            .Where(board => board.BoardID == boardId)
            .Select(boardM => boardM.UserID)
            .ToList();
            return Ok(memberIds);
        }

        public async Task<IActionResult> AddBoardToMember(int userId, int boardId){
            try{
                var existingBoard = await _context.MemberInfo.FirstOrDefaultAsync(board => board.UserID == userId && board.BoardID == boardId);
                if(existingBoard != null){
                    return Conflict("Already on this board.");
                }
                var userBoard = new MemberModel {
                    UserID = userId,
                    BoardID = boardId
                };
                _context.MemberInfo.Add(userBoard);
                await _context.SaveChangesAsync();

                return Ok("Successfully joined board!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding board, {ex.Message}");
            }
        }

        public async Task<IActionResult> AddMemberToBoard(int userId, int boardId){
            try{
                var existingMember = await _context.MemberInfo.FirstOrDefaultAsync(board => board.UserID == userId && board.BoardID == boardId);

                if(existingMember != null){
                    return Conflict("Already on this board");
                }
                var userBoard = new MemberModel{
                    UserID = userId,
                    BoardID = boardId
                };

                _context.MemberInfo.Add(userBoard);
                await _context.SaveChangesAsync();

                return Ok("Successfully joined board!");
            }
            catch (Exception ex) {
                return StatusCode(500, $"Error adding to board, {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoveMemberFromBoard(int userId, int boardId){
            try{
                var userBoard = await _context.MemberInfo.FirstOrDefaultAsync(board => board.UserID ==userId && board.BoardID==boardId);

                if(userBoard == null){
                    return NotFound("User is not on the board");
                }

                _context.MemberInfo.Remove(userBoard);
                await _context.SaveChangesAsync();

                return Ok("Member successfully removed from board");
            }
            catch(Exception ex){
                return StatusCode(500,$"Error removing from board, {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoveBoardFromUser(int userId, int boardId){
            try{
                var userBoard = await _context.MemberInfo.FirstOrDefaultAsync(board => board.UserID==userId && board.BoardID == boardId);
            if(userBoard == null || !userBoard.Any()){
                return NotFound("User is not in board");
            }
            _context.MemberInfo.RemoveRange(userBoard);
            await _context.SaveChangesAsync();

            return Ok("Board removed from user account successfully!");
            }
            catch(Exception ex){
                return StatusCode(500,$"Error removing board from user acc, {ex.Message}");
            }

        }
        
    }
}