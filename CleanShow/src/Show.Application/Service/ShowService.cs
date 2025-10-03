using Show.Application.Dtos;
using Show.Application.Interfaces;
using Show.Domain.Entities;

namespace Show.Application.Service;

public class ShowService : IShowService
{
    private readonly IShowRepository _repository;

    public ShowService(IShowRepository _repository)
    {
        this._repository = _repository;
    }
    public async Task AddAsync(ShowCreateDto dto)
    {
        var show = new Blog
        {
            Title = dto.Title,
            Author = dto.Author,
            Content = dto.Content,
            Tags = dto.Tags,
            PublishedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            Likes = 0,
            Views = 0,
            CommentsCount = 0
        };

        await _repository.InsertAsync(show);
    }

    public async Task<List<ShowGetDto>> GetAllAsync()
    {
        var posts = await _repository.SelectAllAsync();
        return posts.Select(p => new ShowGetDto
        {
            Id = p.Id,
            Title = p.Title,
            Author = p.Author,
            Content = p.Content,
            Tags = p.Tags,
            PublishedDate = p.PublishedDate,
            UpdatedDate = p.UpdatedDate,
            Likes = p.Likes,
            Views = p.Views,
            CommentsCount = p.CommentsCount
        }).ToList();
    }

    public async Task<List<ShowGetDto>> GetAllPagedAsync(ShowFilterParams filterParams)
    {
        var posts = await _repository.SelectAllPagedAsync(filterParams.Skip, filterParams.Take);
        return posts.Select(p => new ShowGetDto
        {
            Id = p.Id,
            Title = p.Title,
            Author = p.Author,
            Content = p.Content,
            Tags = p.Tags,
            PublishedDate = p.PublishedDate,
            UpdatedDate = p.UpdatedDate,
            Likes = p.Likes,
            Views = p.Views,
            CommentsCount = p.CommentsCount
        }).ToList();
    }

    public async Task<ShowGetDto?> GetByIdAsync(long id)
    {
        var post = await _repository.SelectByIdAsync(id);
        if (post == null) return null;

        return new ShowGetDto
        {
            Id = post.Id,
            Title = post.Title,
            Author = post.Author,
            Content = post.Content,
            Tags = post.Tags,
            PublishedDate = post.PublishedDate,
            UpdatedDate = post.UpdatedDate,
            Likes = post.Likes,
            Views = post.Views,
            CommentsCount = post.CommentsCount
        };
    }

    public async Task RemoveAsync(long id)
    {
        var post = await _repository.SelectByIdAsync(id);
        if (post != null)
        {
            await _repository.RemoveAsync(post);
        }
    }

    public async Task UpdateAsync(long id, ShowUpdateDto dto)
    {
        var post = await _repository.SelectByIdAsync(id);
        if (post == null) return;

        post.Title = dto.Title;
        post.Content = dto.Content;
        post.Tags = dto.Tags;
        post.UpdatedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(post);
    }
}
