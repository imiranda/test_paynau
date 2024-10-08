using Microsoft.AspNetCore.Mvc;
using test_api_paynau.Controllers;
using test_api_paynau.Interfaces;
using test_api_paynau.Models;
using test_api_paynau.Repositories;

namespace TestProjectApi
{
    public class PersonsControllerTest1
    {
        PaynauContext context;
        IRepository<Person> repository;
        PersonsController controller;

        public PersonsControllerTest1(PaynauContext _context)
        {
            context = _context;
            repository = new PersonRepository(context);
            controller = new PersonsController(repository);
        }

        [Fact]
        public async Task GetAll_Employee_SuccessAsync()
        {
            var result = await controller.GetPersons();
            var resultType = result.Value as IEnumerable<Person>;
            var resultList = resultType as List<Person>;

            Assert.NotNull(result);
            Assert.IsType<IEnumerable<Person>>(resultList);
        }
    }
}