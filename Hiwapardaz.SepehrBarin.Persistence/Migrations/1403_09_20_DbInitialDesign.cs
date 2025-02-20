using FluentMigrator;
using Hiwapardaz.SepehrBarin.Common.Extensions;
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
                .WithColumn("Nickname").AsString(_255).Nullable()
                .WithColumn("Mobile").AsAnsiString(11).NotNullable()
                .WithColumn("InvalidLoginAttemptCount").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("SerialNumber").AsAnsiString(36).Nullable()
                .WithColumn("LatestLoginDateTime").AsDateTime().Nullable()
                .WithColumn("LockTimespan").AsDateTime().Nullable()
                .WithColumn("ValidFrom").AsDateTime2().NotNullable()
                .WithColumn("ValidTo").AsDateTime2().Nullable()
                .WithColumn("InsertLogInfo").AsString(int.MaxValue).NotNullable()
                .WithColumn("RemoveLogInfo").AsString(int.MinValue).Nullable();
        }
        private void CreateRole()
        {
            var table = TableName.Role;
            Create.Table(nameof(TableName.Role))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Name").AsAnsiString(_255).NotNullable()
                .WithColumn("Title").AsString(_255).NotNullable();
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
                .WithColumn("ValidFrom").AsDateTime2().NotNullable()
                .WithColumn("ValidTo").AsDateTime2().Nullable()
                .WithColumn("InsertLogInfo").AsString(int.MaxValue).NotNullable()
                .WithColumn("RemoveLogInfo").AsString(int.MaxValue).Nullable();
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
                .WithColumn(Id).AsGuid().PrimaryKey(NamingHelper.Pk(table))
                .WithColumn("Mobile").AsString(11).NotNullable()
                .WithColumn($"{nameof(TableName.User)}{Id}").AsGuid().Nullable()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn("LoginDateTime").AsDateTime().NotNullable()
                .WithColumn($"{nameof(TableName.InvalidLoginReason)}{Id}").AsInt16().Nullable()
                    .ForeignKey(NamingHelper.Fk(TableName.InvalidLoginReason, table), nameof(TableName.InvalidLoginReason), Id)
                .WithColumn("ConfirmCode").AsString(6).Nullable()
                .WithColumn("ConfirmExpire").AsDateTime().Nullable()
                .WithColumn("WrongCode").AsString(_1023).Nullable()
                .WithColumn("AppVersion").AsString(15).Nullable()
                .WithColumn("LogoutDateTime").AsDateTime().Nullable()
                .WithColumn($"{nameof(TableName.LogoutReason)}{Id}").AsInt16().Nullable()
                    .ForeignKey(NamingHelper.Fk(TableName.LogoutReason, table), nameof(TableName.LogoutReason), Id)
                .WithColumn("LogInfo").AsAnsiString(int.MaxValue).NotNullable();
        }
        private void CreateNews() {
            var table = TableName.News;
            Create.Table(nameof(TableName.News))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Title").AsString(_255).NotNullable()
                .WithColumn("Summary").AsString(_1023).NotNullable()
                .WithColumn("ImageBase64").AsString(int.MaxValue)
                .WithColumn("Text").AsString(int.MaxValue).NotNullable()
                .WithColumn("AutherId").AsGuid()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn("InsertDateTime").AsDateTime();
        }
        //todo: file repository
        private void CreateMedia() { 
            var table = TableName.Media;
            Create.Table(nameof(TableName.Media))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Address").AsString();
        }
        private void CreateProduct() {
            var table = TableName.Product;
            Create.Table(nameof(TableName.Product))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Image").AsString();     
        }
        //todo: skip for nowd
        private void CreateState()
        {
            var table = TableName.State;
            Create.Table(nameof(TableName.State))
                .WithColumn(Id).AsInt16().PrimaryKey(NamingHelper.Pk(table))
                .WithColumn("Title").AsString().NotNullable();               
        }

        private void CreateRequest()
        {
            var table = TableName.Request;
            Create.Table(nameof(TableName.Request))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("UserId").AsGuid().NotNullable()
                    .ForeignKey(NamingHelper.Fk(TableName.User, table), nameof(TableName.User), Id)
                .WithColumn("Firstname").AsString(_255).NotNullable()
                .WithColumn("Surname").AsString(_255).NotNullable()
                .WithColumn("Nicknames").AsString(int.MaxValue).Nullable()
                .WithColumn("FatherName").AsString(_255).NotNullable()
                .WithColumn("MotherName").AsString(_255).NotNullable()
                .WithColumn("FatherNicknames").AsString(int.MaxValue).Nullable()
                .WithColumn("MotherNicknames").AsString(int.MaxValue).Nullable()
                .WithColumn("Birthday").AsString(_31).NotNullable()
                .WithColumn("EstimatedBirthday").AsString(_31).Nullable()
                .WithColumn("FalseBirthday").AsBoolean()
                .WithColumn("BirthCounty").AsString(_255).NotNullable()
                .WithColumn("BirthProvince").AsString(_255).NotNullable()               
                .WithColumn("BirthCityOrVillage").AsString(_255).NotNullable()
                .WithColumn("LivingCounty").AsString(_255).Nullable()
                .WithColumn("LivingProvince").AsString(_255).Nullable()               
                .WithColumn("LivingCityOrVillage").AsString(_255).Nullable()
                .WithColumn("LivingAddress").AsString(_255).Nullable()
                .WithColumn("LivingPostalCode").AsString(_255).Nullable()
                .WithColumn("Mobile").AsString(11).NotNullable()
                .WithColumn("Description").AsString().Nullable()                
                .WithColumn("ImageBase64").AsString(int.MaxValue).NotNullable()
                .WithColumn("Surgery").AsBoolean()
                .WithColumn("BeforeSurgeryImageBase64").AsString(int.MaxValue).Nullable()
                .WithColumn("ProductTitle").AsString(_255).Nullable()
                .WithColumn("ServiceType").AsString(_255).NotNullable()
                .WithColumn("SubServiceType").AsString(_255).Nullable()
                .WithColumn("Amount").AsInt32().Nullable()
                .WithColumn("ImageClaimPaymentBase64").AsString(int.MaxValue).Nullable()
                .WithColumn("ReferedToId").AsGuid().Nullable()
                .WithColumn("PaymentDescription").AsString(_1023).Nullable()
                .WithColumn("Recipient").AsString(_255).Nullable()
                .WithColumn("BodyParts").AsString(_255).Nullable();
        }

        private void CreateRequestState() 
        { 
            var table = TableName.RequestState;
            Create.Table(nameof(TableName.RequestState))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(table)).Identity()
                .WithColumn("TrackNumber").AsInt32()
                .WithColumn("RequestId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Request, table), nameof(TableName.Request), Id)
                .WithColumn("StateId").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.State, table), nameof(TableName.State), Id)
                .WithColumn("InsertDateTime").AsDateTime().NotNullable()
                .WithColumn("Seen").AsBoolean().NotNullable();
        }
    }
}