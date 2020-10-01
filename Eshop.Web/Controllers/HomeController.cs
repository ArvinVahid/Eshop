using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Eshop.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eshop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;

        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            var products = _userServices.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        #region Product Detail

        public IActionResult Details(int itemId)
        {
            var productById = _userServices.GetProductById(itemId);
            var allCategories = _userServices.GetAllCategories();

            var viewModel = new CategoryProductViewModel()
            {
                Product = productById,
                Categories = allCategories
            };
            return View(viewModel);
        }

        #endregion

        #region Cart

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _userServices.GetProductById(itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _userServices.GetOrderById(userId);
                if (order != null)
                {
                    var orderDetail = _userServices.GetOrderDetail(order, product);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _userServices.AddOrderDetail(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });

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
                    _userServices.AddOrder(order);
                    _userServices.SaveChanges();
                    _userServices.AddOrderDetail(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }

                _userServices.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _userServices.IsOrderFinally(userId);
            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {

            var orderDetail = _userServices.GetDetailId(detailId);
            _userServices.RemoveOrderDetail(orderDetail);
            _userServices.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        #endregion
    }
}
