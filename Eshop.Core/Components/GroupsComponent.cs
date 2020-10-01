using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Core.Components
{
    public class GroupsComponent : ViewComponent
    {
        private IUserServices _userServices;

        public GroupsComponent(IUserServices userServices)
        {
            _userServices = userServices;
        }
       public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _userServices.GetAllCategories();
            return View("/Views/Components/GroupsComponent.cshtml",categories);
        }
    }
}