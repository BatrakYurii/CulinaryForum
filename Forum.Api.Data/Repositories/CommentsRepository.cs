using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly ForumContext _ctx;

        public CommentsRepository(ForumContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Comment> Create(Comment comment)
        {
            _ctx.Comments.Add(comment);
            await _ctx.SaveChangesAsync();
            return comment;

        }

        public async Task Delete(int id, string UserId)
        {
            var baseComment = await _ctx.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (baseComment.UserId != UserId)
            {
                return;
            }
            _ctx.Comments.Remove(baseComment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> Get(int articleId)
        {
            var comments = await _ctx.Comments.Where(x => x.ArticleId == articleId).Include(x => x.Article).Include(x => x.User).AsNoTracking().ToListAsync();
            return comments;
        }

        public async Task<Comment> GetById(int id)
        {
            var comment = await _ctx.Comments
                .Include(x => x.Article)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<Comment> Update(int id, Comment comment, string userId)
        {
            var deleteComment = await _ctx.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
            if(userId != deleteComment.UserId)
            {
               throw new BadHttpRequestException("You have not enough rules");
            }
            _ctx.Comments.Remove(deleteComment);
            comment.Id = id;
            _ctx.Comments.Add(comment);
            await _ctx.SaveChangesAsync();
            return comment;
        }
    }
}
