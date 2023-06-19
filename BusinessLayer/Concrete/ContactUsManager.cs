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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public List<ContactUs> ActiveContactList()
        {
            return _contactUsDal.ActiveContactList();
        }

        public void ChangeContactUsStat(int id)
        {
           _contactUsDal.ChangeContactUsStat(id);
        }

        public ContactUs GetById(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> GetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> PassiveContactList()
        {
            return _contactUsDal.PassiveContactList();
        }

        public void TAdd(ContactUs entity)
        {
            _contactUsDal.Insert(entity);
        }

        public void TDelete(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
        }

        public void TUpdate(ContactUs entity)
        {
            _contactUsDal.Update(entity);
        }
    }
}
