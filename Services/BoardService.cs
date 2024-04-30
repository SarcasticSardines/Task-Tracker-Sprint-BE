using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksprintbe.Models;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Services
{
    public class BoardService
    {
        private readonly DataContext _context;

        public BoardService(DataContext context)
        {
            _context = context;
        }

        public bool AddComment(BoardModel newTaskItem)
        {
            _context.Add(newTaskItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BoardModel> GetAllItems()
        {
            return _context.BoardInfo;
        }

        public IEnumerable<BoardModel> GetBoardByBoardName(int id)
        {
            return _context.BoardInfo.Where(item => item.ID == id);
        }

        public IEnumerable<BoardModel> GetBoardByInviteCode(string code)
        {
            if (code.Length != 6)
            {
                return Enumerable.Empty<BoardModel>();
            }

            //Checks if code is half letters and half digits
            if (code.Take(3).All(char.IsLetter) && code.Skip(3).All(char.IsDigit))
            {
                return _context.BoardInfo.Where(item => item.InviteCode == code);
            }
            // Otherwise the board model is empty
            else
            {
                return Enumerable.Empty<BoardModel>();
            }
        }

        public IEnumerable<BoardModel> GetBoardByMemberList(string members)
        {
            return _context.BoardInfo.Where(item => item.MemberList == members);
        }

        public BoardModel GetBoardItemById(int id)
        {
            return _context.BoardInfo.SingleOrDefault(item => item.ID == id);
        }

        public bool UpdateBoardItem(BoardModel boardUpdate)
        {
            _context.Update<BoardModel>(boardUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool BoardToDelete(BoardModel boardToDelete)
        {
            boardToDelete.IsDeleted = true;
            _context.Update<BoardModel>(boardToDelete);
            return _context.SaveChanges() != 0;
        }
    }
}