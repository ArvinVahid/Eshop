using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Eshop.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eshop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly IOrderServices _orderServices;
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly ICategoryToProductServices _categoryToProductServices;
        private readonly IMapper _mapper;
        public HomeController(IUserServices userServices, IProductServices productServices, IOrderServices orderServices, IOrderDetailServices orderDetailServices, ICategoryToProductServices categoryToProductServices, IMapper mapper)
        {
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
            _orderDetailServices = orderDetailServices;
            _categoryToProductServices = categoryToProductServices;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        #region Product Detail

        public async Task<IActionResult> Details(int itemId, CancellationToken cancellationToken)
        {
            var product = await _productServices.GetProductByIdIncludeItem(itemId, cancellationToken);
            var dto = _mapper.Map<CategoryProductViewModel> (product);

            return View(dto);
        }

        #endregion

        #region Cart

        [Authorize]
        public async Task<IActionResult> AddToCart(int itemId, CancellationToken cancellationToken)
        {
            var product = await _productServices.GetProductByIdIncludeItem(itemId, cancellationToken);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = await _orderServices.GetOrderById(userId, cancellationToken);
                if (order != null)
                {
                    var orderDetail = await _orderDetailServices.GetOrderDetail(order, product, cancellationToken);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        await _orderDetailServices.AddOrderDetail(new OrderDetail()
                        {
                            OrderId = order.Id,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        }, cancellationToken);

                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    await _orderServices.AddOrder(order, cancellationToken);
                    await _userServices.SaveChangeAsync(cancellationToken);
                    await _orderDetailServices.AddOrderDetail(new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    }, cancellationToken);
                }

                await _userServices.SaveChangeAsync(cancellationToken);
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public async Task<IActionResult> ShowCart(CancellationToken cancellationToken)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = await _orderServices.IsOrderFinally(userId, cancellationToken);
            return View(order);
        }

        [Authorize]
        public async Task<IActionResult> RemoveCart(int detailId, CancellationToken cancellationToken)
        {

            var orderDetail = await _orderDetailServices.GetDetailId(detailId, cancellationToken);
            await _orderDetailServices.RemoveOrderDetail(orderDetail, cancellationToken);
            await _userServices.SaveChangeAsync(cancellationToken);
            return RedirectToAction("ShowCart");
        }

        #endregion
    }
}
