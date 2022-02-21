using System;
using HockeyGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HockeyGame.Application.Tests;

public static class HockeyGameContextFactory
{
    public static HockeyGameContext CreateContext()
    {
        DbContextOptionsBuilder<HockeyGameContext> dbOptions = new DbContextOptionsBuilder<HockeyGameContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        return new HockeyGameContext(dbOptions.Options);
    }
}