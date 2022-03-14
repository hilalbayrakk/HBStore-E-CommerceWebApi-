using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly HBStoreDbContext _context;

        public CommentRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var result = _context.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteComment(Comment comment)
        {
            var result = _context.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllComment()
        {
            return await _context.Comments.ToListAsync();
        }
        public async Task<Comment> GetCommentById(int id)
        {
           return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Comment>> GetAllCommentByCustomerId(int customerId)
        {
            return await _context.Comments.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Comment>> GetAllCommentByProductId(int productId)
        {
            return await _context.Comments.Where(x => x.ProductId == productId).ToListAsync();
        }


    }
}