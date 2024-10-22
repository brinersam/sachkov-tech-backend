﻿using CSharpFunctionalExtensions;
using NotificationService.Entities;
using NotificationService.HelperClasses;
using NotificationService.Infrastructure;

namespace NotificationService.Features.Commands
{
    public class AddNotificationSettingsHandler
    {
        private readonly ApplicationDbContext _dbContext;
        public AddNotificationSettingsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Guid,Error>> Handle(
            AddNotificationSettingsCommand command,
            CancellationToken cancellationToken = default)
        {
            // todo test make sure it sets correct settings by default

            var emailRes = Email.Create(command.Email);
            if (emailRes.IsFailure)
                return emailRes.Error;

            var notificationSettingsResult = NotificationSettings.Create(
                Guid.NewGuid(),
                command.UserId,
                emailAddress: emailRes.Value,
                webEndpoint: command.WebEndpoint!);

            if (notificationSettingsResult.IsFailure)
                return notificationSettingsResult.Error;

            await _dbContext.NotificationSettings.AddAsync(notificationSettingsResult.Value);
            await _dbContext.SaveChangesAsync();

            return notificationSettingsResult.Value.Id;
        }
    }
}
