using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class HeroBannerDTo
    {
        public int Id { get; set; }
        public string Text_One { get; set; }
        public string Text_Two { get; set; }
        public string Text_Three { get; set; }
        public string? Image_One { get; set; }
        public string? Image_Two { get; set; }
        public string? Image_Three { get; set; }
    }
}
