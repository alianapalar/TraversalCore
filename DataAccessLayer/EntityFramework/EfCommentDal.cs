﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
            using (var context=new Context()) 
            {
                return context.Comments.Include(x=>x.Destination).Include(x=>x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var context=new Context()) 
            {
                return context.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentWithUserAndDestination(int id)
        {
            using(var context=new Context()) 
            {
                return context.Comments.Where(x => x.AppUserID == id).Include(x => x.Destination).ToList();
            }
        }
    }
}
