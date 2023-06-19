using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }
        public List<Comment> GetDestinationById(int id) 
        {
            return _commentDal.GetListByFilter(x=>x.DestinationID== id);
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public void TUpdate(Comment entity)
        {
           _commentDal.Update(entity);
        }

        public List<Comment> GetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }

        public List<Comment> GetListCommentWithUserAndDestination(int id)
        {
            return _commentDal.GetListCommentWithUserAndDestination(id);
        }
    }
}
