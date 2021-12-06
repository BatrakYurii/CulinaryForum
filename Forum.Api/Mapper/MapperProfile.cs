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
            CreateMap<UserPostModel, User>();
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
            //CreateMap<ArticleModel, Article>();
            CreateMap<Article, ArticleModel>()
                .ForMember(model => model.Categories,
                opts => opts
                .MapFrom(entity => entity.ArticlesCategories));
            CreateMap<CommentModel, Comment>();
            CreateMap<Comment, CommentModel>();
            CreateMap<Image, string>();
            //CreateMap<string, Image>()
            //    .ForMember(entity => entity.Path,
            //    opts => opts
            //    .MapFrom(str => str));
            CreateMap<CategoryPostModel, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            CreateMap<CategoryModel, CategoryViewModel>();
            CreateMap<CuisineNationalityPostModel, CuisineNationalityModel>();
            CreateMap<CuisineNationalityModel, CuisineNationalityViewModel>();
            CreateMap<CuisineNationality, CuisineNationalityModel>();
            CreateMap<CuisineNationalityModel, CuisineNationalityViewModel>();
            CreateMap<CuisineNationalityModel, CuisineNationality>()
                .ForMember(entity => entity.Id, opts => opts.Ignore());

            CreateMap<Image, string>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = src.Path;
                    return dest;
                });
            CreateMap<string, Image>()
                .ForMember(entity => entity.Path,
                opts => opts
                .MapFrom(model => model.Select(img => new { Path = img })));

         
            CreateMap<ArticleModel, Article>()
                .ForMember(entity => entity.ArticlesCategories,
                opts => opts
                .MapFrom(model => model.Categories))
                .ForMember(entity => entity.Images,
                opts => opts
                .MapFrom(model => model.Images.Select(img => new Image { Path = img, ArticleId = model.Id })));
            CreateMap<CategoryModel, ArticlesCategories>()
                .ForMember(entity => entity.CategoryId,
               opts => opts
               .MapFrom(model => model.Id))
                .ForMember(entity => entity.Id, opts => opts.Ignore());
            CreateMap<ArticlesCategories, CategoryModel>()
                .ForMember(model => model.Id,
                opts => opts.MapFrom(entity => entity.CategoryId))
                .ForMember(model => model.Title,
                 opts => opts.MapFrom(entity => entity.Category.Title));

            //CreateMap<Skeleton, SkeletonModel>();
            //CreateMap<Human, HumanModel>()
            //    .ForMember(humanModel => humanModel.Skeleton, opts => opts.MapFrom(src => src.Skeletons.FirstOrDefault()));
        }
    }
}
