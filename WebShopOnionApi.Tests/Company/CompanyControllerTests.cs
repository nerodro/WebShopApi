using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Cart;
using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Products;
using ServiceLayer.Property.CompanyService;
using ServiceLayer.Property.ProductServce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Controllers;
using WebShop.Models;

namespace WebShopOnionApi.Tests
{
    [TestClass]
    public class CompanyControllerTests
    {
        CompanyController _controller;
        ICompanyService _companyService;
        IProductService _productService;
        private readonly ApplicationContext context;
        public CompanyControllerTests()
        {
            _companyService = new CompanyServiceFake();
            this._controller = new CompanyController(_companyService, _productService);
        }
        [TestMethod]
        public void TestAdd()
        {
            CompanyViewModel company = new CompanyViewModel()
            {
                CompanyIdentity = "Test1",
                CompanyNamme = "Test1",
            };
            var createResponse = _controller.AddCompany(company) as CreatedAtActionResult;
            var item = createResponse.Value as CompanyViewModel;
            Assert.AreEqual(item.CompanyNamme, company.CompanyNamme);

        }
        [TestMethod]
        public void TestAddAbsent()
        {
            CompanyViewModel company = new CompanyViewModel()
            {
                CompanyIdentity = "Test2",
                CompanyNamme = "Test2",
            };
            var createResponse = _controller.AddCompany(company) as CreatedAtActionResult;
            var item = createResponse.Value as CompanyViewModel;
            Assert.AreNotEqual(item.CompanyNamme, "Test3");
        }
        [TestMethod]
        public void TestAddNull()
        {
            CompanyViewModel company = new CompanyViewModel()
            {
                CompanyIdentity = null,
                CompanyNamme = null,
            };
            var createResponse = _controller.AddCompany(company) as CreatedAtActionResult;
            var item = createResponse.Value as CompanyViewModel;
            Assert.IsNull(item.CompanyNamme);
        }
    }
}
