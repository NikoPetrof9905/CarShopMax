﻿using CarShopMax.Helpers;
using CarShopMax.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarShopMax.Services.Generic;

public class UserRepository(CarShopMaxContext cont, IValidator<User> valid) : IUserRepository
{

    private readonly CarShopMaxContext _context = cont;
    private readonly IValidator<User> _validator = valid;

    public async Task<User> AuthenticateUserAsync(string username, string password)
    {
        if (!await UserExistsAsync(username)) throw new Exception("User does not exist!");
        var loadedUser = await _context.Users.FirstAsync(x => x.Username == username && x.Password == HashHelper.ComputeSha256Hash(password));
        return loadedUser;
    }

    public async Task DeleteUserAsync(string username)
    {
        if (!await UserExistsAsync(username)) throw new Exception("User does not exist!");
        await _context.Users.Where(x => x.Username == username).ExecuteDeleteAsync();
    }

    public async Task<User[]> GetUsersAsync()
    {
        return await _context.Users.ToArrayAsync();
    }

    public async Task<User> SaveUserAsync(User user)
    {
        if (await UserExistsAsync(user.Username)) throw new Exception("User already exists!");
        _validator.ValidateAndThrow(user);
        user.Password = HashHelper.ComputeSha256Hash(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        if (!await UserExistsAsync(user.Username)) throw new Exception("User does not exist!");
        _validator.ValidateAndThrow(user);
        var loadedUser = await _context.Users.FirstAsync(x => x.Username == user.Username);
        loadedUser.Email = user.Email;
        user.Password = HashHelper.ComputeSha256Hash(user.Password);
        loadedUser.ProfileImage = user.ProfileImage;
        await _context.SaveChangesAsync();
        return loadedUser;
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(x => x.Username == username);
    }
}
