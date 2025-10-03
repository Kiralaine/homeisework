namespace Season.Application.Dtos;

public class SeasonGetDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Tags { get; set; } = null!;
    public DateTime PublishedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; }
    public int CommentsCount { get; set; }
}
