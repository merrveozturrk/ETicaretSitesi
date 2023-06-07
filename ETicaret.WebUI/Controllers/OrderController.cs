using ETicaret.BusinessLayer.Abstract;
using ETicaret.Entities;
using ETicaret.WebUI.Identity;
using ETicaret.WebUI.Models;
using ETicaret.WebUI.ViewModels;
using Iyzipay.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class OrderController:Controller
    {
        private IOrderService _orderService;
        private UserManager<User> _userManager;
        public OrderController( IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
             

            var userId = _userManager.GetUserId(User);

            var order = _orderService.GetOrders(userId);

            return View(order);
        }
    }
}
