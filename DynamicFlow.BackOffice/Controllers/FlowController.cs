using DynamicFlow.BackOffice.Models.DynamicFlow;
using DynamicFlow.BackOffice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DynamicFlow.BackOffice.Controllers
{
    public class FlowController(IService _service) : Controller
    {
        public async Task<IActionResult> CreateFlow() //yes
        {
            var response = await _service.GetCreateFlow();
            ViewData["DbConnections"] = response.dbConnection;
            ViewData["Buttons"] = response.button;
            return View("CreateFlow");
        }

        public async Task<IActionResult> SetupFlow()//Yes
        {
            var response = await _service.GetSetupFlow();
            ViewData["Flow"] = response;
            return View("SetupFlow");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/CreateNewFlow")]
        public async Task<IActionResult> CreateNewFlow([FromBody] CreateFlowViewModel model)//yes
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.CreateFlow(model);
                    if (response.ResponseCode.Equals("00"))
                    {
                        return Json(new { success = true, message = response.ResponseMessage });

                    }
                    return Json(new { success = false, message = response.ResponseMessage });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new { success = false, message = "Invalid data submitted." });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/SaveFlow")]
        public async Task<IActionResult> SaveFlow([FromBody] SaveFlowViewModel model)//Yes
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.SaveFlow(model);
                    if (response.ResponseCode.Equals("00"))
                    {
                        return Json(new { success = true, message = response.ResponseMessage });

                    }
                    return Json(new { success = false, message = response.ResponseMessage });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new { success = false, message = "Invalid data submitted." });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/GetAllProcedure")]
        public async Task<IActionResult> GetAllProcedure([FromBody] GetAllProcedureViewModel model) //yes
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.GetAllProcedure(model);
                    return Json(new { success = true, data = response });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Invalid data submitted." });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/FlowProperty")]
        public async Task<IActionResult> GetFlowProperties([FromBody] GetProcedureViewModel model)//Yes
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.FlowProperty(model);
                    return Json(new { success = true, data = response });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Invalid data submitted." });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/DeleteFlow")]
        public async Task<IActionResult> DeleteFlow([FromBody] GetAllProcedureViewModel model) //yes
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.DeleteFlow(model);
                    return Json(new { success = true, data = response });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Invalid data submitted." });
        }
    }
}
