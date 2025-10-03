using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Application.Dtos;

public class SportFilterParams
{
    public int Skip { get; set; }
    public int Take { get; set; }
}
