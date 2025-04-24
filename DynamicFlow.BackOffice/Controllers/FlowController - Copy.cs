using DynamicFlow.BackOffice.Models.DynamicFlow;
using DynamicFlow.BackOffice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DynamicFlow.BackOffice.Controllers
{
    public class FlowController(IService _service) : Controller
    {
        public async Task<IActionResult> CreateFlow()
        {

            var response = await _service.GetCreateFlow();
            ViewData["DbConnections"] = response.dbConnection;
            ViewData["DbScripts"] = response.dbScript;
            ViewData["Buttons"] = response.button;
            return View("CreateFlow");
        }

        public async Task<IActionResult> CreateProperty()
        {
            var response = await _service.GetCreateProperty();
            ViewData["PropertyType"] = response.propertyType;
            ViewData["DataType"] = response.dataType;
            ViewData["DataSource"] = response.dataSource;
            ViewData["EventType"] = response.eventType;
            ViewData["ParentProperty"] = response.parentProperty;
            ViewData["DbScript"] = response.dbScript;
            return View("CreateProperty");
        }

        public async Task<IActionResult> SetupFlow()
        {
            var response = await _service.GetSetupFlow();
            //ViewData["Flow"] = response.flow;
            //ViewData["Property"] = response.property;
            return View("SetupFlow");
        }

        public async Task<IActionResult> SetupFlowNew()
        {
            var response = await _service.GetSetupFlow();
            ViewData["Flow"] = response;
            return View("SetupFlowNew");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Flow/CreateFlow")]
        public async Task<IActionResult> CreateFlow([FromBody] CreateFlowViewModel model)
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
        [Route("Flow/CreateProperty")]
        public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.CreateProperty(model);
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
        [Route("Flow/SetupFlow")]
        public async Task<IActionResult> SetupFlow([FromBody] SetupFlowViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.SetupFlow(model);
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
        [Route("Flow/GetProcedure")]
        public async Task<IActionResult> GetProcedure([FromBody] GetProcedureViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.GetProcedure(model);
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
        public async Task<IActionResult> GetFlowProperties([FromBody] GetProcedureViewModel model)
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
        [Route("Flow/GetParameter")]
        public async Task<IActionResult> GetParameter([FromBody] GetParameterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.GetParameter(model);
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
