using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApp.Components;
using LoginApp.Models;
using LoginApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static LoginApp.Components.Enums.Api;

namespace LoginApp.Controllers
{
    public class MembershipController : Controller
    {
        private UserRepository userRepository;
        public MembershipController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]JToken req)
        {
            JToken data = req["data"];

            var username = data.Value<string>("username");
            var email = data.Value<string>("email");
            var password = data.Value<string>("password");
            var passwordRepeat = data.Value<string>("passwordRepeat");

            if (string.IsNullOrEmpty(username))
                return Json(new ApiResponse(Error.MissingData) { data = nameof(username) });

            if (string.IsNullOrEmpty(email))
                return Json(new ApiResponse(Error.MissingData) { data = nameof(email) });

            if (string.IsNullOrEmpty(password))
                return Json(new ApiResponse(Error.MissingData) { data = nameof(password) });

            if (password != passwordRepeat)
                return Json(new ApiResponse(Error.PasswordsMustMatch));

            if (!Validation.IsValidPassword(password))
                return Json(new ApiResponse(Error.PasswordIsNotValid));
            
            User u = new User()
            {
                username = username,
                email = email,
                password = password
            };

            int userId = await userRepository.RegisterAsync(u);

            if (userId <= 0)
                return Json(new ApiResponse(Error.PhoneIsAlreadyUsed));

            u.id = userId;

            return Json(new ApiResponse(new { }));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]JToken req)
        {
            JToken data = req["data"];

            var email = data.Value<string>("email");
            var password = data.Value<string>("password");

            string finalEmail = "";
            if (email.Contains("@"))
                finalEmail = email;
            else
                finalEmail = email;

            if (string.IsNullOrEmpty(email))
                return Json(new ApiResponse(Error.MissingData) { data = nameof(email) });

            if (string.IsNullOrEmpty(password))
                return Json(new ApiResponse(Error.MissingData) { data = nameof(password) });

            if (!string.IsNullOrEmpty(phone) && !Validation.IsValidPhone(phone))
                return Json(new ApiResponse(Error.PhoneIsNotValid));

            if (!string.IsNullOrEmpty(email) && !Validation.IsValidEmail(finalEmail))
                return Json(new ApiResponse(Error.EmailIsNotValid));

            var user = await userRepository.LoginAsync(phone, email);

            if (user == null)
                return Json(new ApiResponse(Error.EmailNotRegistered));
            else if (user.password != password)
                return Json(new ApiResponse(Error.PasswordIsWrong));

            return Json(new ApiResponse(user));
        }

    }
}