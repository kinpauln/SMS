using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Entities
{
    public class Book
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int BookId { get; set; }

        [DisplayName("书名")]
        [Required(ErrorMessage = "必须输入书名")]
        public string Name { get; set; }

        [DisplayName("出版日期")]
        [Required(ErrorMessage = "必须输入出版日期")]
        public DateTime PublishDate { get; set; }

        [DisplayName("作者")]
        [StringLength(10, ErrorMessage = "最多允许输入十个字符")]
        [Required(ErrorMessage = "必须输入作者")]
        public string Author { get; set; }

        [DisplayName("价格")]
        [Range(1, 200, ErrorMessage = "书的价格必须在￥1-￥200之间")]
        [Required(ErrorMessage = "必须输入价格")]
        public double Price { get; set; }

        [DisplayName("销量")]
        public int Sales { get; set; }

        [DisplayName("市场")]
        public Area MarketArea { get; set; }

        //[DisplayName("国家")]
        //public string MarketNation { get; set; }

        //[DisplayName("省")]
        //public string MarketProvince { get; set; }

        //[DisplayName("城市")]
        //public string MarketCity { get; set; }
    }
}
