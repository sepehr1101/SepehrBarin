using FluentMigrator;
using Hiwapardaz.SepehrBarin.Persistence.Extensions;
using Hiwapardaz.SepehrBarin.Persistence.Migrations.Enums;
using System.Reflection;

namespace Hiwapardaz.SepehrBarin.Persistence.Migrations
{
    [Migration(1403092001)]
    public class DbInitialDesign : Migration
    {
        string Id = nameof(Id), Hash = nameof(Hash);
        int _31=31, _255 = 255, _1023 = 1023;
        public override void Up()
        {
            var methods =
               GetType()
              .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(m => m.Name.StartsWith("Create"))
              .ToList();
            methods.ForEach(m => m.Invoke(this, null));
        }
        public override void Down()
        {
            var tableNames =
              GetType()
             .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
             .Where(m => m.Name.StartsWith("Create"))
             .Select(m=>m.Name.Replace("Create",string.Empty))
             .ToList();
            tableNames.ForEach(t => Delete.Table(t));
        }
        private void CreateUser()
        {
            var table = TableName.User;
            Create.Table(nameof(TableName.User))
                .WithColumn(Id).AsGuid().PrimaryKey(NamingHelper.Pk(table))               
                .WithColumn("FullName").AsString(_255).NotNullable()
                .WithColumn("DisplayName").AsString(_255).NotNullable()
                .WithColumn("Username").AsString(_255).Unique(NamingHelper.Uq(table,"Username")).NotNullable()
                .WithColumn("Password").AsString(int.MaxValue).NotNullable()
                .WithColumn("Mobile").AsAnsiString(11).NotNullable()
                .WithColumn("MobileConfirmed").AsBoolean().NotNullable()    
                .WithColumn("HasTwoStepVerification").AsBoolean().NotNullable()
                .WithColumn("InvalidLoginAttemptCount").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("SerialNumber").AsAnsiString(36).Nullable()
                .WithColumn("LatestLoginDateTime").AsDateTime().Nullable()
                .WithColumn("LockTimespan").AsDateTime().Nullable()
                .WithColumn("PreviousId").AsGuid().Nullable()
                     .ForeignKey(NamingHelper.Fk(table, table, "PreviousId"), nameof(TableName.User), Id)
                .WithColumn("ValidFrom").AsDateTime2().NotNullable()
                .WithColumn("ValidTo").AsDateTime2().Nullable()
                .WithColumn("InsertLogInfo").AsString(int.MaxValue).NotNullable()
                .WithColumn("RemoveLogInfo").AsString(int.MinValue).Nullable()
                .WithColumn(Hash).AsString(int.MaxValue).NotNullable();
        }
        private void CreateRole()
        {
            var table = TableName.Role;
            Create.Table(nameof(TableName.Role))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Name").AsAnsiString(_255).NotNullable() 
                .WithColumn("Title").AsString(_255).NotNullable()
                .WithColumn("DefaultClaims").AsString(int.MaxValue).Nullable()
                .WithColumn("SensitiveInfo").AsBoolean().NotNullable()
                .WithColumn("IsRemovable").AsBoolean().NotNullable()
                .WithColumn("PreviousId").AsInt32().Nullable()
                    .ForeignKey(NamingHelper.Fk(table, table, "PreviousId"), nameof(TableName.Role), Id)
                .WithColumn("ValidFrom").AsDateTime2().NotNullable()
                .WithColumn("ValidTo").AsDateTime2().Nullable()
                .WithColumn("InsertLogInfo").AsString(int.MaxValue).NotNullable()
                .WithColumn("RemoveLogInfo").AsString(int.MinValue).Nullable()
                .WithColumn(Hash).AsString(int.MaxValue).NotNullable();
        }
        private void CreateUserRole()
        {
            var table = TableName.UserRole;
            Create.Table(nameof(TableName.UserRole))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn($"{nameof(TableName.User)}{Id}").AsGuid().NotNullable()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn($"{nameof(TableName.Role)}{Id}").AsInt32().NotNullable()
                    .ForeignKey(NamingHelper.Fk(TableName.Role, TableName.UserRole), nameof(TableName.Role), Id)
                .WithColumn("InsertGroupId").AsGuid().NotNullable()
                .WithColumn("RemoveGroupId").AsGuid().NotNullable()
                .WithColumn("ValidFrom").AsDateTime2().NotNullable()
                .WithColumn("ValidTo").AsDateTime2().Nullable()
                .WithColumn("InsertLogInfo").AsString(int.MaxValue).NotNullable()
                .WithColumn("RemoveLogInfo").AsString(int.MinValue).Nullable()
                .WithColumn(Hash).AsString(int.MaxValue).NotNullable();
        }
        private void CreateUserToken()
        {
            var table = TableName.UserToken;
            Create.Table(nameof(TableName.UserToken))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn($"{nameof(TableName.User)}{Id}").AsGuid().NotNullable()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn("AccessTokenExpiresDateTime").AsDateTime().NotNullable()
                .WithColumn("AccessTokenHash").AsString(_1023).NotNullable()
                .WithColumn("RefreshTokenExpiresDateTime").AsDateTime().NotNullable()
                .WithColumn("RefreshTokenIdHash").AsString(_1023).NotNullable()
                .WithColumn("RefreshTokenIdHashSource").AsString(_1023).Nullable();
        }

        private void CreateInvalidLoginReason()
        {
            var table = TableName.InvalidLoginReason;
            Create.Table(nameof(TableName.InvalidLoginReason))
                .WithColumn(Id).AsInt16().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Title").AsString(_255).NotNullable();
        }
        private void CreateLogoutReason()
        {
            var table = TableName.LogoutReason;
            Create.Table(nameof(TableName.LogoutReason))
                .WithColumn(Id).AsInt16().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Title").AsString(_255).NotNullable();
        }
        private void CreateUserLogin()
        {            
            var table = TableName.UserLogin;
            Create.Table(nameof(TableName.UserLogin))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Username").AsString(_255).NotNullable()
                .WithColumn($"{nameof(TableName.User)}{Id}").AsGuid().Nullable()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn("FirstStepDateTime").AsDateTime().NotNullable()
                .WithColumn("Ip").AsAnsiString(15).NotNullable()
                .WithColumn("FirstStepSuccess").AsBoolean().NotNullable()
                .WithColumn($"{nameof(TableName.InvalidLoginReason)}{Id}").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.InvalidLoginReason, table), nameof(TableName.InvalidLoginReason), Id)
                .WithColumn("WrongPassword").AsString(_1023).Nullable()
                .WithColumn("AppVersion").AsString(15).NotNullable()
                .WithColumn("TwoStepCode").AsAnsiString(15).Nullable()
                .WithColumn("TwoStepExpireDateTime").AsDateTime().Nullable()
                .WithColumn("TwoStepInsertDateTime").AsDateTime().Nullable()
                .WithColumn("TwoStepWasSuccessful").AsBoolean().Nullable()
                .WithColumn("PreviousFailureIsShown").AsBoolean().NotNullable()
                .WithColumn("LogoutDateTime").AsDateTime().Nullable()
                .WithColumn($"{nameof(TableName.LogoutReason)}{Id}").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.LogoutReason, table), nameof(TableName.LogoutReason), Id)
                .WithColumn("LogInfo").AsAnsiString(int.MaxValue).NotNullable();
        }       
    }
}