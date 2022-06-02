using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
//using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {

        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            this._context= context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //return await Mediator.Send(new List.Query());
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id) 
        {
            // return await Mediator.Send(new Details.Query{Id=id});
             return await _context.Activities.FindAsync(id);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateActivity(Activity activity)
        // {
        //     // return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        // {
        //     activity.Id = id;
        //    // return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteActivity(Guid id)
        // {
        //    // return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        // }
    }
}