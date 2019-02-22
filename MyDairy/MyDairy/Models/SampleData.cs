using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyDiary.Models
{
    public class SampleData:DropCreateDatabaseAlways<DiaryDB>
    {
        protected override void  Seed(DiaryDB context)
        {
            context.Users.Add(new User { 
                UserName = "sjl",
                Password = "12345" ,
                Diaries = new List<Diary> {

                    new Diary{Title="hello1",Content="This is the Content1",PubDate=DateTime.Now },
                    new Diary{Title="hello2",Content="This is the Content2",PubDate=DateTime.Now },
                    new Diary{Title="hello3",Content="This is the Content3",PubDate=DateTime.Now }

                }
            });

            context.Users.Add(new User
            {
                UserName = "sjl2",
                Password = "12345",
                Diaries = new List<Diary> {

                    new Diary{Title="hello4",Content="This is the Content4",PubDate=DateTime.Now },
                    new Diary{Title="hello5",Content="This is the Content5",PubDate=DateTime.Now },
                    new Diary{Title="hello6",Content="This is the Content6",PubDate=DateTime.Now }

                }
            });
            //把赋值完的context给基类
            base.Seed(context);

        }
    }
}