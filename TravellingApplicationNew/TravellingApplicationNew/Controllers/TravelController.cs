using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingApplicationNew.Models;
using TravellingApplicationNew.Repository;

namespace TravellingApplicationNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        ITravelRepository travelRepository;
        public TravelController(ITravelRepository _p)
        {
            travelRepository = _p;
        }

        //--------------------------------Project-----------------------------------
        //Get All Users
        
        #region GetAllUsers
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var user = await travelRepository.GetAllUsers();
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Get User By Id
        #region GetUserById

        [HttpGet]
            [Route("GetUserById")]
            public async Task<IActionResult> GetUserById(int id)
                 {
                    try
                     {
                         var user = await travelRepository.GetUserById(id);
                          if (user != null)
                            {
                                return Ok(user);
                            }
                           return NotFound();
                     }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
        #endregion

        //update users
        #region update Users
     
        [HttpPut]
        // [Authorize]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(Registration user)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await travelRepository.UpdateUser(user);
                    return Ok(user);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Add user
        //[Authorize]
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(Registration user)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await travelRepository.AddUser(user);
                    if (userId != null)
                    {
                        return Ok(userId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


        //-----------------------------Request------------------------------------

        //Get All Request

        #region GetAllRequests
        [HttpGet]
        [Route("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var request = await travelRepository.GetAllRequests();
                if (request == null)
                {
                    return NotFound();
                }
                return Ok(request);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Get request By Id
        #region GetRequestById

        [HttpGet]
        [Route("GetRequestById")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            try
            {
                var request = await travelRepository.GetRequestById(id);
                if (request != null)
                {
                    return Ok(request);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //update request
        #region update request

        [HttpPut]
        // [Authorize]
        [Route("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest(RequestTable request)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await travelRepository.UpdateRequest(request);
                    return Ok(request);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Add request
        //[Authorize]
        [HttpPost]
        [Route("AddRequest")]
        public async Task<IActionResult> AddRequest(RequestTable request)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var reqId = await travelRepository.AddRequest(request);
                    if (reqId != null)
                    {
                        return Ok(reqId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion
        //----------------------------------PROJECT-------------------------------------------

        //Get All Project

        #region GetAllProjects
        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var project = await travelRepository.GetAllProjects();
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Get project By Id
        #region GetProjectById

        [HttpGet]
        [Route("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var project = await travelRepository.GetProjectById(id);
                if (project != null)
                {
                    return Ok(project);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //update project
        #region update project

        [HttpPut]
        // [Authorize]
        [Route("UpdateProject")]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await travelRepository.UpdateProject(project);
                    return Ok(project);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //Add Project
        #region Add Project
        //[Authorize]
        [HttpPost]
        [Route("AddProject")]
        public async Task<IActionResult> AddProject(Project project)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var proId = await travelRepository.AddProject(project);
                    if (proId != null)
                    {
                        return Ok(proId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


    }
}
