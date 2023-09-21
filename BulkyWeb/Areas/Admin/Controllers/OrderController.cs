using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> objOrderheaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");

            switch (status)
            {
                case "pending":
                    objOrderheaders = objOrderheaders.Where(u => u.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    objOrderheaders = objOrderheaders.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objOrderheaders = objOrderheaders.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objOrderheaders = objOrderheaders.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:                    
                    break;
            }

            return Json(new { data = objOrderheaders });
        }


        #endregion
    }
}
