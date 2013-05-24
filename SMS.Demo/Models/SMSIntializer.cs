
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Domain;
using SMS.Entities;
using System.Data.Entity;

namespace SMS.UI.Mvc3.Demo.Models
{
    public class SMSIntializer: DropCreateDatabaseIfModelChanges<SMSContext>
    {
        protected override void Seed(SMSContext context)
        {
            var books = new List<Book> { 
                 new Book {  Name = "钢铁是怎样炼成的",  
                             PublishDate=DateTime.Parse("2001-01-11"), 
                             Author="奥斯特洛夫斯基", 
                             Price=17.00,
                             Sales=100,
                             MarketArea=new Area(){
                                 Nation="中国",
                                 Province="山东",
                                 City="青岛"
                             }
                           },  

                 new Book {  Name = "巴黎圣母院", 
                             PublishDate=DateTime.Parse("1980-02-23"), 
                             Author="雨果", 
                             Price=19.98,
                             Sales=200,
                             MarketArea=new Area(){
                                 Nation="中国",
                                 Province="广东",
                                 City="深圳"
                             }
                           }

             };
            books.ForEach(d => context.Books.Add(d));
            context.SaveChanges();

            var users = new List<User> { 
                 new User {  UserName = "Kinpauln",  
                      Password="123456",
                       Email="kinpauln@126.com"
                           }
             };
            users.ForEach(d => context.Users.Add(d));
            context.SaveChanges();
        }
    }
}