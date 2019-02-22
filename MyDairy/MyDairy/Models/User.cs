using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiary.Models
{
    public class User
    {
        
        //这些属性是什么意思 
        [Key]
         [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("UserName"),Required]
        public string UserName { get; set; }

        [DisplayName("Password"),Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Dairies")]
        public virtual List<Diary> Diaries { get; set; }
    }
}