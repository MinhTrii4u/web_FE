using System.Web.Mvc;
using System.Collections.Generic;
using web_FE.Models; // Quan trọng: Để Controller hiểu User và Order

namespace web_FE.Controllers
{
    public class AccountController : Controller
    {
        // === DỮ LIỆU GIẢ (GIỐNG NHƯ TRONG FILE POWERPOINT) ===
        private static User userFake = new User
        {
            Name = "Lã Minh Trí",
            Email = "laminhtri197@gmail.com",
            Phone = "0765413705",
            Address = "200 Đ. 3 Tháng 2, Phường 12, Quận 10, Thành phố Hồ Chí Minh",
            Password = "123"
        };

        private static List<Order> ordersFake = new List<Order>
        {
            new Order { Id = 101, Date = "20/09/2025", Item = "Adidas Superstar XLG", Quantity = 1, Total = 2800000, Status = "Đã giao" },
            new Order { Id = 102, Date = "15/10/2025", Item = "Adidas Samba OG", Quantity = 2, Total = 6400000, Status = "Đang xử lý" }
        };
        // === KẾT THÚC DỮ LIỆU GIẢ ===


        // GET: Account/Login
        public ActionResult Login()
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            return View();
        }

        // POST: Xử lý Đăng Nhập
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email == userFake.Email && password == userFake.Password)
            {
                Session["user"] = userFake;
                return RedirectToAction("Account");
            }
            ViewBag.Error = "Sai email hoặc mật khẩu.";
            return View();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu xác nhận không khớp.";
                return View();
            }
            TempData["Success"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }

        // GET: Account/Account (Trang thông tin tài khoản)
        public ActionResult Account()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // === ACTION MỚI ĐỂ CẬP NHẬT THÔNG TIN ===
        [HttpPost]
        public ActionResult UpdateProfile(string name, string phone, string address)
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                // Nếu session mất, quay về trang đăng nhập
                return RedirectToAction("Login");
            }

            // Cập nhật thông tin cho đối tượng userFake (và cả trong Session)
            userFake.Name = name;
            userFake.Phone = phone;
            userFake.Address = address;

            // Lưu lại thông tin mới vào Session
            Session["user"] = userFake;

            // Gửi thông báo thành công sang View
            ViewBag.Msg = "Cập nhật thông tin thành công!";

            // Hiển thị lại trang Account với thông tin đã được cập nhật
            return View("Account", userFake);
        }
        // === KẾT THÚC ACTION MỚI ===

        // GET: Account/Orders (Lịch sử đơn hàng)
        public ActionResult Orders()
        {
            var user = Session["user"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            // Gửi danh sách đơn hàng giả sang View làm Model
            return View(ordersFake);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            Session.Clear(); // XÓA SESSION
            return RedirectToAction("Index", "Home"); // Về trang chủ
        }
    }
}