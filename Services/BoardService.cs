using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tasksprintbe.Models;
using tasksprintbe.Services.Context;

namespace tasksprintbe.Services
{
    public class BoardService
    {
        private readonly DataContext _context;
        private readonly Random _random;

        public BoardService(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public bool AddBoard(BoardModel newTaskItem)
        {
            //Add random code to the newly created board table
            newTaskItem.InviteCode = GenerateRandomInviteCode();

            _context.Add(newTaskItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BoardModel> GetAllBoards()
        {
            return _context.BoardInfo;
        }

        public IEnumerable<BoardModel> GetBoardByBoardName(string name)
        {
            return _context.BoardInfo.Where(item => item.BoardName == name);
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

        public BoardModel GetBoardById(int id)
        {
            return _context.BoardInfo.SingleOrDefault(item => item.ID == id);
        }

        public bool UpdateBoard(BoardModel boardUpdate)
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

        public string GenerateRandomInviteCode()
        {
            const string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            StringBuilder inviteCodeBuilder = new StringBuilder();

            // Generate the first 3 characters (capital letters)
            for (int i = 0; i < 3; i++)
            {
                inviteCodeBuilder.Append(upperCaseLetters[_random.Next(upperCaseLetters.Length)]);
            }

            // Generate the final 3 characters (numbers)
            for (int i = 0; i < 3; i++)
            {
                inviteCodeBuilder.Append(numbers[_random.Next(numbers.Length)]);
            }
            
            return inviteCodeBuilder.ToString();
        }
    }
}