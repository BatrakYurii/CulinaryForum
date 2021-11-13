using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Api.Data.Entities;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.ViewModels;
using Forum.Api.Services.Models;

namespace Forum.Api.Mapper
{
    public class MapperProfile : Profile
    {
        //PL
        public MapperProfile()
        {
            CreateMap<UserPostModel, UserModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<ArticlePostModel, ArticleModel>();
            CreateMap<Article, ArticleViewModel>();
            CreateMap<ArticleModel, ArticleViewModel>();
            CreateMap<CommentPostModel, CommentModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<CommentModel, CommentViewModel>();
            //CreateMap<HumanModel, HumanViewModel>();

            //BL

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<ArticleModel, Article>();
            CreateMap<Article, ArticleModel>();
            CreateMap<CommentModel, Comment>();
            CreateMap<Comment, CommentModel>();
            //CreateMap<Skeleton, SkeletonModel>();
            //CreateMap<Human, HumanModel>()
            //    .ForMember(humanModel => humanModel.Skeleton, opts => opts.MapFrom(src => src.Skeletons.FirstOrDefault()));
        }
    }
}
