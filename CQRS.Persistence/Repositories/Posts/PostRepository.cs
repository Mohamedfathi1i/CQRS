using CQRS.Application.Contracts;
using CQRS.Domain.Entities;
using CQRS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Persistence.Repositories.Posts
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> allposts = new List<Post>();
            allposts = includeCategory ? await _dbContext.Posts.Include(p => p.Category).ToListAsync() : await _dbContext.Posts.ToListAsync();
            return allposts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post post = new Post();
            post = includeCategory ? await _dbContext.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id) : await GetByIdAsync(id);
            return post;
        }
    }
}
