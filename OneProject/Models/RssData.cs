using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneProject.Models
{
    public static class RssData
    {
        public static List<Category> Categories { get; set; }

        public static void LoadCategories()
        {
            Categories = new List<Category>();

            Categories.Add(new Category
            {
                Link = @"https://rss.walla.co.il/feed/1?type=main",
                Title = "חדשות"
            });
            Categories.Add(new Category
            {
                Link = @"https://rss.walla.co.il/feed/3?type=main",
                Title = "ספורט"
            }); Categories.Add(new Category
            {
                Link = @"https://rss.walla.co.il/feed/2?type=main",
                Title = "כסף"
            }); Categories.Add(new Category
            {
                Link = @"https://rss.walla.co.il/feed/31?type=main",
                Title = "רכב"
            });

        }
    }
}