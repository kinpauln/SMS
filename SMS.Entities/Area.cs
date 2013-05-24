using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SMS.Entities
{
    public class Area
    {
        [DisplayName("国家")]
        public string Nation { get; set; }
        [DisplayName("省")]
        public string Province { get; set; }
        [DisplayName("城市")]
        public string City { get; set; }
    }
}
