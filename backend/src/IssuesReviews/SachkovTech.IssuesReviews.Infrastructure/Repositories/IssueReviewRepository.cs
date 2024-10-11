﻿using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SachkovTech.IssuesReviews.Application;
using SachkovTech.IssuesReviews.Domain;
using SachkovTech.IssuesReviews.Infrastructure.DbContexts;
using SachkovTech.SharedKernel;
using SachkovTech.SharedKernel.ValueObjects.Ids;

namespace SachkovTech.IssuesReviews.Infrastructure.Repositories;

public class IssueReviewRepository : IIssueReviewRepository
{
    private readonly WriteDbContext _dbContext;

    public IssueReviewRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<IssueReview, Error>> GetById(IssueReviewId id,
        CancellationToken cancellationToken = default)
    {
        var issueReview = await _dbContext.IssueReviews
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        if (issueReview == null)
            return Errors.General.NotFound(id);

        return issueReview;
    }
}