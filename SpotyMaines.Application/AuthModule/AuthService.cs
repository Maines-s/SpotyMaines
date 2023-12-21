using FluentResults;
using Microsoft.AspNetCore.Identity;
using Serilog;
using SpotyMaines.Domain.AutenticationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Application.AuthModule
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result<User>> RegisterAsync(User user, string password)
        {
            Result validationResult = Validate(user);

            if (validationResult.IsFailed)
                return Result.Fail(validationResult.Errors);

            var userResult = await userManager.CreateAsync(user, password);

            if (userResult.Succeeded == false)
                return Result.Fail(userResult.Errors.Select(x => x.Description));

            return Result.Ok(user);
        }

        public async Task<Result<User>> AuthenticateAsync(string userName, string password)
        {
            var loginResult = await signInManager.PasswordSignInAsync(userName, password, false, true);

            var errors = new List<Error>();

            if (loginResult.IsLockedOut)
                errors.Add(new Error("O acesso desse úsuario foi blockeado!"));

            if (loginResult.IsNotAllowed)
                errors.Add(new Error("Login ou senha incorretos!"));

            if (!loginResult.Succeeded)
                errors.Add(new Error("Login ou senha incorretos"));

            if (errors.Any())
                return Result.Fail(errors);

            var user = await userManager.FindByNameAsync(userName);

            return Result.Ok(user);
        }

        public async Task<Result<User>> Exit()
        {
            await signInManager.SignOutAsync();

            return Result.Ok();
        }

        public Result Validate(User user)
        {
            var validator = new UserValidator();

            var result = validator.Validate(user);

            var errors = new List<Error>();

            foreach (var error in result.Errors)
            {
                Log.Logger.Warning(error.ErrorMessage);

                errors.Add(new Error(error.ErrorMessage));
            }

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }
    }
}
