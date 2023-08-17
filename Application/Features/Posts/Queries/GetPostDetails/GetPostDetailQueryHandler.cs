using AutoMapper;
using CQRS.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, GetPostDetailViewModel>
    {

        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;
        public GetPostDetailQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _PostRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetPostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _PostRepository.GetPostByIdAsync(request.PostId, true);
            return _mapper.Map<GetPostDetailViewModel>(post);
        }
    }
}
