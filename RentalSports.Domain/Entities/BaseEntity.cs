using Flunt.Notifications;
using System.Linq;

namespace RentalSports.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public string Id { get; protected set; }

        public abstract void Validate();

        public string NotificationError
            => this.Notifications?.FirstOrDefault()?.Message ?? "";

        public bool Invalid
            => !this.IsValid;

        public virtual bool IsEmpty()
            => string.IsNullOrEmpty(Id);

        public void AddNotification(string message)
        {
            this.AddNotification(nameof(BaseEntity), message);
        }
    }
}
