using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetDestinationById(int id);
        List<Comment> GetListCommentWithDestination();
        List<Comment> GetListCommentWithDestinationAndUser(int id);
        public List<Comment> GetListCommentWithUserAndDestination(int id);
    }
}
