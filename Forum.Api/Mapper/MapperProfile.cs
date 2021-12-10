using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Common.Enums;
using Forum.Api.Data.Entities;
using Forum.Api.Data.Parameters;
using Forum.Api.Models.PostModels;
using Forum.Api.Models.QueryParams;
using Forum.Api.Models.ViewModels;
using Forum.Api.Services.Models;
using Forum.Api.Services.Models.Parameters;

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

            //BL
            CreateMap<CommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<CookingTimePostModel, TimeSpan>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = new TimeSpan(src.Hours, src.Minutes, 0);
                    return dest;
                });
            CreateMap<TimeSpan, CookingTimeViewModel>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = new CookingTimeViewModel();

                    dest.Hours = src.Hours;
                    dest.Minutes = src.Minutes;
                    //dest.Hours = (int)Math.Floor(src.TotalHours);
                    //dest.Minutes = src.Hours;
                    return dest;
                });

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


            CreateMap<PaginationPostModel, PаginationModel>();
            CreateMap<SortingPostModel, SortingModel>();
            CreateMap<FiltersPostModel, FiltersModel>();

            CreateMap<PаginationModel, Pagination>();
            CreateMap<Pagination, PаginationModel>();
            CreateMap<Pagination, PaginationViewModel>();
            CreateMap<SortingModel, Sorting>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    if (!src.SortDirection.HasValue)
                    {
                        return null;
                    }
                    dest = new Sorting();
                    dest.IsAscending = src.SortDirection == SortDirectionEnum.Ascending;
                    dest.SortingExpression = article => article.CreateDate;
                   
                    return dest;
                }
                );
            CreateMap<FiltersModel, Filter>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = new Filter();
                    dest.Predicates = new List<Expression<Func<Article, bool>>>();
                    if (src.CreateDateFrom.HasValue)
                    {
                        dest.Predicates.Add(article => article.CreateDate >= src.CreateDateFrom);
                    }
                    if (src.CreateDateTo.HasValue)
                    {
                        dest.Predicates.Add(article => article.CreateDate <= src.CreateDateTo);
                    }
                    if (src.CategoryId.HasValue)
                    {
                        dest.Predicates.Add(article => article.ArticlesCategories.Any(c => c.CategoryId == src.CategoryId));
                    }
                    if (src.NationalityId.HasValue)
                    {
                        dest.Predicates.Add(article => article.CuisineNationalityId == src.NationalityId);
                    }
                    if (src.IsVegan.HasValue)
                    {
                        if (src.IsVegan == true)
                            dest.Predicates.Add(article => article.IsVegan == true);
                    }
                    if (!string.IsNullOrEmpty(src.SearchingRequest))
                    {
                        dest.Predicates.Add(article => article.Title.Contains(src.SearchingRequest));
                        dest.Predicates.Add(article => article.Content.Contains(src.SearchingRequest));
                    }
                    if (dest.Predicates.Count == 0)
                    {
                        return null;
                    }
                    return dest;
                });
        }
    }
}
