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
        //CompanyController _controller;
        //ICompanyService _companyService;
        //IProductService _product;
        //private IProducts<Products> _products;
        //private ICompany<Company> _company;
        //private ICart<Cart> _cart;
        //private readonly ApplicationContext context;
        //public CompanyControllerTests()
        //{
        //    this._products = new ProductLogic(context);
        //    this._companyService = new CompanyService(_products, _company);
        //    this._product = new ProductService(_products, _company, _cart);
        //    this._controller = new CompanyController(_companyService,_product);
        //}
        //[TestMethod]
        //public void TestAdd()
        //{
        //    CompanyViewModel company = new CompanyViewModel()
        //    {
        //        CompanyIdentity = "Test",
        //        CompanyNamme = "Test44",
        //    };
        //    var response = _controller.AddCompany(company);
        //    var createdComp = response as CreatedAtActionResult;
        //    var comapanys = createdComp.Value as CompanyViewModel;
        //    Assert.AreEqual(company.CompanyNamme, comapanys.CompanyNamme);
        //}
    }
}
