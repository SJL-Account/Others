using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    public class Diary
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
       
        [DisplayName("Title"), Required]
        public string Title { get; set; }
        
        [DisplayName("Content"), Required]
        public string Content { get; set; }
        
        [DisplayName("DateTime"),DataType(DataType.DateTime)]
        public DateTime? PubDate { get; set; }
        
        [DisplayName("UserId")]
        public int UserId { get; set; }

        //为了预加载，打点索引出User
        [DisplayName("User")]
        public virtual User   user { get; set; }

    }
}