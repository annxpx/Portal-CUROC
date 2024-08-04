﻿using Application.Contracts;
using Application.Features.Authentication.Commands;
using Application.Features.Authentication.Models;
using Domain.Contracts;
using Domain.Entities;
using Domain.Errors;
using Mediator;
using Shared;

namespace Application.Features.Authentication.CommandHandlers;

public class RegisterUserCommandHandler(
    IUserMailer userMailer,
    IUserRepository userRepository
    )
    : ICommandHandler<RegisterUserCommand, Result>
{
    public async ValueTask<Result> Handle(RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var emailExist = await userRepository.EmailExistsAsync(request.Email, cancellationToken);
        if (emailExist) return Result.Failure<TokenResponse>(AuthenticationErrors.EmailInUse);
        
        var token = Guid.NewGuid().ToString();
        var newUser = new User
        {
            Email = request.Email,
            EmailConfirmationToken = token,
            EmailConfirmationSentAt = DateTime.UtcNow,
            EmailConfirmationTokenExpiresAt = DateTime.UtcNow.AddDays(3)
        };
        await userRepository.AddAsync(newUser, cancellationToken);

        await userMailer.SendConfirmationInstructionsAsync(newUser.Email, token, cancellationToken);
        
        return Result.Success();
    }
}