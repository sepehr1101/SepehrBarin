using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Implementations
{
    public class StateSeeder : IDataSeeder
    {
        public int Order { get; set; } = 1;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<State> _states;
        public StateSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(Order));

            _states = _uow.Set<State>();
            _states.NotNull(nameof(_states));
        }

        public void SeedData()
        {
            if (_states.Any())
            {
                return;
            }
            var states = new List<State>()
            {
                new State() { Id=StateIdEnum.Registered,Title="درخواست ثبت شد" },
                new State() { Id=StateIdEnum.Confirmed,Title="تایید اولیه درخواست" },
                new State() { Id=StateIdEnum.NeedModification , Title="نیاز به اصلاح توسط درمانجو"},
                new State() { Id=StateIdEnum.Rejected , Title="رد شد"},
                new State() { Id=StateIdEnum.PaymentNotified , Title="اعلام هزینه شد"},
                new State() { Id=StateIdEnum.PaymentClaimed , Title="ادعای درخواست توسط درمانجو"},
                new State() { Id=StateIdEnum.PaymentConfirmed , Title="تایید پرداخت"},
                new State() { Id=StateIdEnum.ChatStarted , Title="شروع گفتگو"},
                new State() { Id=StateIdEnum.Finished , Title="پایان درخواست"}
            };
            _states.AddRange(states);
            _uow.SaveChanges();
        }
    }
}
