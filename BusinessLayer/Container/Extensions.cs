using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.ContactUsValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services) 
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal,EfReservationDal>();
            services.AddScoped<IGuideService,GuideManager>();
            services.AddScoped<IGuideDal,EfGuideDal>();
            services.AddScoped<IExcelService, ExcelManager>();  
            services.AddScoped<IPdfService,PdfManager>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal,EfContactUsDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal,EfAnnouncementDal>();
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal,EfAccountDal>();
            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal,EfSubAboutDal>();
            services.AddScoped<ITestimonialService,TestimonialManager>();
            services.AddScoped<ITestimonialDal,EfTestimonialDal>(); 
            services.AddScoped<IUowDal,UowDal>();

        }
        public static void CustomerValidator(this IServiceCollection services) 
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
            services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
        }
        //public static void ConfigureLogFactory(this IServiceCollection services,ILoggingBuilder logging) 
        //{
        //    string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Log1.txt");
        //    logging.AddFile(logFilePath);
        //}
    }
}
