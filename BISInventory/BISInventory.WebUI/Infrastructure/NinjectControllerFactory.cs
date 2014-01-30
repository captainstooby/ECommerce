using BISInventory.Domain.Abstract;
using BISInventory.Domain.Concrete;
using BISInventory.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;


namespace BISInventory.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //Put bindings here

            //Mock implementation binding below

            bool bindMockRepository = false;

            if (bindMockRepository)
            {
                Mock<IProductRepository> mockRepository = new Mock<IProductRepository>();
                mockRepository
                    .Setup(m => m.Products)
                    .Returns(new List<Product>
                {
                    new Product { Name = "Football", Price = 25 },
                    new Product { Name = "Surf board", Price = 179 },
                    new Product { Name = "Running Shoes", Price = 95 }
                }.AsQueryable());

                ninjectKernel.Bind<IProductRepository>().ToConstant(mockRepository.Object);
            }
            else
            {
                //Real implementation binding below
                ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>(); 
            }
        }
    }
}