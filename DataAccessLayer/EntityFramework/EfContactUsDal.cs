using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Migrations;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public List<ContactUs> ActiveContactList()
        {
            Context c = new Context();
            var values = c.ContactUses.Where(x => x.MessageStatus == true).ToList();
            return values;
        }

        public void ChangeContactUsStat(int id)
        {
            Context c = new Context();
            var contactUs = c.ContactUses.Find(id);

            contactUs.MessageStatus = contactUs.MessageStatus ? false : true;
            c.SaveChanges();

        }

        public List<ContactUs> PassiveContactList()
        {
            Context c = new Context();
            var values = c.ContactUses.Where(x => x.MessageStatus == false).ToList();
            return values;
        }
    }
}
