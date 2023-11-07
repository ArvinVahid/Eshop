using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Web.Components
{
    public class GroupsComponent : ViewComponent
    {
        private readonly ICategoryServices _categoryServices;
        public GroupsComponent(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var categories = await _categoryServices.GetAllCategories(cancellationToken);
            return View("/Views/Components/GroupsComponent.cshtml", categories);
        }
    }
}