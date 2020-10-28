using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public HomeController(IUserServices userServices, IProductServices productServices, IOrderServices orderServices, IMapper mapper)
        {
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productServices.GetAllProducts();
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
            var product = _productServices.GetProductByIdForDTO(itemId);

            var dto = _mapper.ProjectTo<CategoryProductViewModel>(product)
                .SingleOrDefault(p => p.ItemId == itemId);

            return View(dto);
        }

        #endregion

        #region Cart

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _productServices.GetProductById(itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _orderServices.GetOrderById(userId);
                if (order != null)
                {
                    var orderDetail = _orderServices.GetOrderDetail(order, product);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _orderServices.AddOrderDetail(new OrderDetail()
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
                    _orderServices.AddOrder(order);
                    _userServices.SaveChanges();
                    _orderServices.AddOrderDetail(new OrderDetail()
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
            var order = _orderServices.IsOrderFinally(userId);
            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {

            var orderDetail = _orderServices.GetDetailId(detailId);
            _orderServices.RemoveOrderDetail(orderDetail);
            _userServices.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        #endregion
    }
}
