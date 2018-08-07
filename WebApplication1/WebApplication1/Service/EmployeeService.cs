using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication1.DbModels;
using WebApplication1.Models;

namespace WebApplication1.Service
{

    public class EmployeeService
    {
	    public IList<Person> Search(out int totalCount,
		    DateTime? startDate, DateTime? endDate,
		    int start = 0, int pageSize = 10, string sortField = "", string sortDirection = "desc", string search = "")
	    {
		    totalCount = 0;

		    try
		    {
			    using (var context = new EmployeeContext())
			    {
				    var query = context.Person.Where
				    (x => (x.Name.Contains(search) ||
				           string.IsNullOrEmpty(search)));

				    var records = query.OrderByEx(sortDirection, sortField)
					    .Skip(start).Take(pageSize)
					    .ToList();

				    totalCount = query.Count();

				    return records;
			    }
		    }
		    catch (Exception ex)
		    {
				//TODO log
			    return new List<Person>();
		    }
	    }

		public IList<Person> All()
	    {
		    try
		    {
			    using (var context = new EmployeeContext())
			    {
				    var all = context.Person.ToList();
				    return all;
			    }
		    }
		    catch (Exception ex)
		    {
				return new List<Person>();
		    }
	    }

	    public bool AddOrUpdate(Person p)
	    {
		    try
		    {
			    using (var  context = new EmployeeContext())
			    {
				    var record = context.Person.FirstOrDefault(x => x.Id == p.Id);
				    if (record != null)
				    {
					    MapperEx.MapExceptID<Person,Person>(p, ref record);
					    context.SaveChanges();
				    }
				    else
				    {
					    var newObj = MapperEx.CreateFrom<Person,Person>(p);
						newObj.CreatedAt = DateTime.Now;
					    context.Person.Add(newObj);
					    context.SaveChanges();
				    }
			    }

			    return true;
		    }
		    catch (Exception ex)
		    {
			    return false;
		    }
	    }

	    public bool DeleteById(long id)
	    {
		    try
		    {
			    using (var  context = new EmployeeContext())
			    {
				    var tryFind = context.Person.FirstOrDefault(x => x.Id == id);
				    if (tryFind != null)
				    {
					    context.Person.Remove(tryFind);
					    context.SaveChanges();
				    }
			    }

			    return true;
		    }
		    catch (Exception ex)
		    {
			    return false;
		    }
	    }

	    public Person GetById(long id)
	    {
		    try
		    {
			    using (var context = new EmployeeContext())
			    {
				    var record = context.Person.FirstOrDefault(x => x.Id == id);
				    return record;
			    }
		    }
		    catch (Exception ex)
		    {
				return new Person();
		    }
	    }
    }
}
