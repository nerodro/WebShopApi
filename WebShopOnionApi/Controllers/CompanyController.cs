using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Infrascructure.Company;
using ServiceLayer.Property.CompanyService;
using ServiceLayer.Property.ProductServce;
using System.Data;
using TestOnion.Models;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _company;
        private readonly IProductService _product;
        private ApplicationContext context;

        public CompanyController(ICompanyService company, IProductService product)
        {
            this._company = company;
            this._product = product;
        }

        [HttpGet("GelAllProducts")]
        //[Authorize(Roles = "admin, moder,user")]
        public IEnumerable<CompanyViewModel> Index()
        {
            List<CompanyViewModel> model = new List<CompanyViewModel>();
            if (_company != null)
            {
                _company.GetAll().ToList().ForEach(u =>
                {
                    CompanyViewModel company = new CompanyViewModel
                    {
                        Id = u.Id,
                        CompanyIdentity = u.CompanyIdentity,
                        CompanyNamme = u.CompanyNamme,
                    };
                    model.Add(company);
                });
            }

            return model;
        }


        [HttpPost("CreateCompany")]
        public ActionResult AddCompany(CompanyViewModel company)
        {
            Company company1 = new Company
            {
                CompanyNamme = company.CompanyNamme,
                CompanyIdentity = company.CompanyIdentity,
            };
            _company.Create(company1);
            if (company1.Id > 0)
            {
                return Ok(company);
            }
            return BadRequest();
        }

        [HttpPut("EditCompany")]
        public async Task<ActionResult<CompanyViewModel>> EditCompany(CompanyViewModel model)
        {
            Company company = _company.Get(model.Id);
            company.CompanyNamme = model.CompanyNamme;
            company.ModifiedDate = DateTime.UtcNow;
            company.CompanyIdentity = model.CompanyIdentity;
            _company.Update(company);
            if (company.Id > 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCompany/{id}")]
        public ActionResult DeleteCompany(long id)
        {
            Company company = _company.Get(id);
            _company.Delete(id);
            return Ok(company);
        }
        [HttpGet("GetSingleCompany/{id}")]
        public ActionResult CompanyProfile(int? id)
        {
            CompanyViewModel model = new CompanyViewModel();
            if (id.HasValue && id != 0)
            {
                Company company = _company.Get(id.Value);
                model.Id = company.Id;
                model.CompanyIdentity = company.CompanyIdentity;
                model.CompanyNamme = company.CompanyNamme;
                return new ObjectResult(model);
            }
            return BadRequest();
        }
    }
}
