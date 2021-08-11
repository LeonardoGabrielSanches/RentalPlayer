using Flunt.Notifications;
using System;
using System.Linq;

namespace RentalSports.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }

        public abstract void Validate();

        public string NotificationError
            => this.Notifications?.FirstOrDefault()?.Message ?? "";

        public bool Invalid
            => !this.IsValid;

        public virtual Guid GenerateNewGuid()
            => Guid.NewGuid();

        public virtual bool IsEmpty()
            => Id == Guid.Empty;
    }
}
