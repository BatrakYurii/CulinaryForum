using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
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

        public async Task Delete(int id)
        {
            var comment = await _ctx.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
            _ctx.Comments.Remove(comment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> Get()
        {
            var comments = await _ctx.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> Get(int id)
        {
            var comment = await _ctx.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<Comment> Update(int id, Comment comment)
        {
            var deleteComment = await _ctx.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
            _ctx.Comments.Remove(deleteComment);
            comment.Id = id;
            _ctx.Comments.Add(comment);
            await _ctx.SaveChangesAsync();
            return comment;
        }
    }
}
