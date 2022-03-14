using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface ICommentRepository
    {
        Task<Comment> AddComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task<List<Comment>> GetAllComment();
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentByCustomerId(int customerId);
        Task<List<Comment>> GetCommentByProductId(int productId);
    }
}