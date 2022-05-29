using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Matriculas.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
    }


}
