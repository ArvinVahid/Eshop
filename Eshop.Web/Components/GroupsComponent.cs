using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Web.Components
{
    public class GroupsComponent : ViewComponent
    {
        private IProductServices _productServices;

        public GroupsComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _productServices.GetAllCategories();
            return View("/Views/Components/GroupsComponent.cshtml", categories);
        }
    }
}