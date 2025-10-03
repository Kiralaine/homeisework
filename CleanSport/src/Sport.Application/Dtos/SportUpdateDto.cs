using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Application.Dtos;

public class SportUpdateDto
{
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
