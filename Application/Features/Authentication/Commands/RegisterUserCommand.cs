﻿using Mediator;
using Shared;

namespace Application.Features.Authentication.Commands;

public record RegisterUserCommand(string Email): ICommand<Result>;