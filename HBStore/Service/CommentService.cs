namespace HBStore.Service
{
    public class CommentService : ControllerBase, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            var result = _commentRepository.GetCommentById(comment.Id);
            if (result == null)
            {
                return await _commentRepository.AddComment(comment);
            }
            throw new InvalidOperationException("Ayni id'ye sahip baska bir yorum bulunuyor!");
        }

        public async Task<Comment> UpdateComment(Comment comment, int id)
        {
            var result = await _commentRepository.GetCommentById(id);
            if (result != null)
            {
                await _commentRepository.DeleteComment(comment);
            }
            throw new InvalidOperationException("Guncellenecek yorum bulunamadi!");
        }

        public async Task DeleteComment(Comment comment)
        {
            var result = _commentRepository.GetCommentById(comment.Id);
            if (result != null)
            {
                await _commentRepository.DeleteComment(comment);
            }
            throw new InvalidOperationException("Silinecek yorum bulunamadi!");
        }

        public async Task<List<Comment>> GetAllComment()
        {
            return await _commentRepository.GetAllComment();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _commentRepository.GetCommentById(id);
        }

        public async Task<List<Comment>> GetAllCommentByCustomerId(int customerId)
        {
            return await _commentRepository.GetAllCommentByCustomerId(customerId);
        }

        public async Task<List<Comment>> GetAllCommentByProductId(int productId)
        {
            return await _commentRepository.GetAllCommentByProductId(productId);
        }


    }
}