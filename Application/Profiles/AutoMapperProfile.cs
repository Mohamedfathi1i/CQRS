using AutoMapper;
using CQRS.Application.Features.Posts.Commands.CreatePost;
using CQRS.Application.Features.Posts.Queries.GetPostDetails;
using CQRS.Application.Features.Posts.Queries.GetPostsList;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostsListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
        }
    }
}
