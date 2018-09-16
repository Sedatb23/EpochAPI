using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpochApi.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        protected IEnumerable GetModelErrors()
        {
            return ModelState
                            .Select(st => new { field = st.Key, error = st.Value.Errors.FirstOrDefault()?.ErrorMessage })
                            .Where(x => ModelState[x.field].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid);
        }
    }
}
