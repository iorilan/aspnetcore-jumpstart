using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCRUD.DbModels;
using WebApiCRUD.Modesl;

namespace WebApi_CRUD.Controllers
{
    
    public class EmployeeController : Controller
    {
	    [Route("api/Employee/All")]
		[HttpGet]
	    public async Task<ActionResult> GetAllAsync()
	    {
		    try
		    {
			    var repository = new EmployeeContext();
			    var results = await repository.Person.ToListAsync();

				return Ok(ApiResult<IList<Person>>.Ok(results));
		    }
		    catch (Exception ex)
		    {
			    return Ok(ApiResult<IList<Person>>.Error(ex));
			}
	    }

	    [Route("api/Employee/{id}")]
		[HttpGet("{id}")]
	    [ProducesResponseType(404)]
	    public async Task<ActionResult> GetByIdAsync(int id)
	    {
		    try
		    {
			    var repository = new EmployeeContext();
			    var person = await repository.Person.FirstOrDefaultAsync(x => x.Id == id);

			    if (person == null)
			    {
				    return NotFound();
			    }

			    return Ok(ApiResult<Person>.Ok(person));
		    }
		    catch (Exception ex)
		    {
			    return Ok(ApiResult<Person>.Error(ex));
			}
	    }

	    [Route("api/Employee/Update")]
	    [HttpPost]
	    [ProducesResponseType(400)]
	    public async Task<ActionResult> UpdateAsync(Person p)
	    {
		    try
		    {
			    if (!ModelState.IsValid)
			    {
				    return BadRequest(ModelState);
			    }

			    var repository = new EmployeeContext();

			    var tryFind = await repository.Person.FirstOrDefaultAsync(x => x.Id == p.Id);
			    if (tryFind != null)
			    {
				    tryFind.Address = p.Address;
				    tryFind.Age = p.Age;
				    tryFind.IdNumber = p.IdNumber;
				    await repository.SaveChangesAsync();
			    }

			    return Ok(ApiResult.Ok());
			}
		    catch (Exception ex)
		    {
			    return Ok(ApiResult.Error(ex));
			}
		 
		}

		[Route("api/Employee/Create")]
		[HttpPost]
	    [ProducesResponseType(400)]
	    public async Task<ActionResult> CreateAsync(Person p)
	    {
		    try
		    {
			    if (!ModelState.IsValid)
			    {
				    return BadRequest(ModelState);
			    }

			    var repository = new EmployeeContext();
			    await repository.Person.AddAsync(p);
			    await repository.SaveChangesAsync();

			    return Ok(ApiResult.Ok());
			}
		    catch (Exception ex)
		    {
			    return Ok(ApiResult.Error(ex));
			}
		}
	}
}
