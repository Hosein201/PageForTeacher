using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domain.Contracts;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Contracts;
using Service.ServiceDomain;
using System;


namespace SettingApp
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServiceWithAutofac(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(UnitOfWork)).As<IUnitOfWork>().InstancePerDependency();
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            containerBuilder.RegisterType<JwtService>().As<IJwtService>().SingleInstance();

            containerBuilder.RegisterType(typeof(UserRepository)).As<IUserRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(UserService)).As<IUserService>().InstancePerDependency();

            containerBuilder.RegisterType(typeof(SupportRepository)).As<ISupportRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(SupportService)).As<ISupportService>().InstancePerDependency();

            containerBuilder.RegisterType(typeof(TeacherRepository)).As<ITeacherRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(TeacherService)).As<ITeacherService>().InstancePerDependency();

            containerBuilder.RegisterType(typeof(StudentRepository)).As<IStudentRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(StudentService)).As<IStudentService>().InstancePerDependency();

            containerBuilder.RegisterType(typeof(PaymentRepository)).As<IPaymentRepository>().InstancePerDependency();


            containerBuilder.RegisterType(typeof(FieldRepository)).As<IFieldRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(FieldService)).As<IFieldService>().InstancePerDependency();

            containerBuilder.RegisterType(typeof(EduRepository)).As<IEduRepository>().InstancePerDependency();
            containerBuilder.RegisterType(typeof(EduService)).As<IEduService>().InstancePerDependency();
        }

        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.AddServiceWithAutofac();

            IContainer container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
