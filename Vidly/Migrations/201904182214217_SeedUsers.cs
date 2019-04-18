namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a866c4c-714d-4118-b58c-b0f2ad42b989', N'guest@vidly.com', 0, N'AIeuLpu6T9Jjyjzu2Z7aBH6bILoNqy/FSw8fhYyl+9/gc2Q77C2dXrOUvB5N4ZjYFg==', N'97ee9211-9dfd-40bb-93bc-49d49f23acb7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b719b99c-42ac-4076-8ae1-e704792f1829', N'admin@vidly.com', 0, N'AM1eYpZwuE6uyilDALq/95xwUIlgOJAzDYW4Fy5gEAwVxOaQgPpwjiuAHDbabeBRoQ==', N'56cab835-ab10-4d8d-b684-e524f481a119', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0e28260-7c65-4c57-a89b-f06b492bb5e6', N'CanManageMovies')
          	INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b719b99c-42ac-4076-8ae1-e704792f1829', N'a0e28260-7c65-4c57-a89b-f06b492bb5e6')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
