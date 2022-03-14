using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface ICommentService
    {
        
        Task<Comment> AddComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment, int id);
        Task DeleteComment(Comment comment);
        Task<List<Comment>> GetAllComment();
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetAllCommentByCustomerId(int customerId);
        Task<List<Comment>> GetAllCommentByProductId(int productId);
    }
}