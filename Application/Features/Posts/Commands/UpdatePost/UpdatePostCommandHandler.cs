using AutoMapper;
using CQRS.Application.Contracts;
using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            await _postRepository.UpdateAsync(post);
        }
    }
}
