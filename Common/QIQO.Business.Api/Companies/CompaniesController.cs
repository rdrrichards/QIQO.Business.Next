using Microsoft.AspNetCore.Mvc;
using QIQO.Companies.Domain;
using QIQO.Companies.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Companies
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesManager _companiesManager;

        public CompaniesController(ICompaniesManager companiesManager)
        {
            _companiesManager = companiesManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Company1", "Company2" });
            return Ok(await _companiesManager.GetCompaniesAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _companiesManager.GetCompanyAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CompanyAddViewModel companyAddViewModel)
        {
            if (ModelState.IsValid)
            {
                await _companiesManager.SaveCompanyAsync(new Company(companyAddViewModel.CompanyCode,
                    companyAddViewModel.CompanyName, companyAddViewModel.CompanyDesc));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]CompanyUpdateViewModel companyUpdateViewModel)
        {
            await _companiesManager.UpdateCompanyAsync(new Company(companyUpdateViewModel.CompanyCode,
                    companyUpdateViewModel.CompanyName, companyUpdateViewModel.CompanyDesc));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companiesManager.DeleteCompanyAsync(id);
            return Ok();
        }
    }
}
