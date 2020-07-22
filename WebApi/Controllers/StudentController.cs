using System;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Application.Students.Commands;
using Application.Students.Queries;
using Application.Students.Responses;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {

    [Route("api/students")]
    public class StudentController : ApiController {

        public StudentController(IMediator mediator, IApplicationDbContext context) :
            base(mediator, context) { }

                   
        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody]CreateStudentCommand command) {
            await mediator.Send(command);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<StudentDetails> GetStudentAsync(Guid id) {
            return await mediator.Send(new GetStudentDetailsQuery() { Id = id });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(Guid id, [FromBody]UpdateStudentCommand command) {
            if(id != command.Id) {
                return BadRequest("The query string ID doesn't match the ID inside the DTO.");
            }

            await mediator.Send(command);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(Guid id) {
            await mediator.Send(new DeleteStudentCommand() { Id = id });
            return NoContent();
        }
    }
}
