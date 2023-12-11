using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace SpotyMaines.Controllers.Shared
{
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult ProcessResult(Result result, object viewModel = null)
        {
            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(viewModel);
        }

        public override OkObjectResult Ok(object? value)
        {
            return base.Ok(new
            {
                Success = true,
                Data = value
            });
        }

        public override BadRequestObjectResult BadRequest(object? error)
        {
            IList<IError> errors = (IList<IError>)error;

            return base.BadRequest(new
            {
                Success = false,
                Errors = errors.Select(x => x.Message)
            });
        }

        public override NotFoundObjectResult NotFound(object? value)
        {
            IList<IError> errors = (List<IError>)value;

            return base.NotFound(new
            {
                Success = false,
                Errors = errors.Select(x => x.Message)
            });
        }
    }
}
