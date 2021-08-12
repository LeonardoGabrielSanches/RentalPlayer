using Flunt.Notifications;
using Flunt.Validations;
using RentalSports.Domain.ValueObject;
using System;

namespace RentalSports.Domain.Entities
{
    public class Player : User
    {
        public Player() { }

        public Player(
           Guid id,
           string name,
           string email,
           string password,
           decimal height,
           decimal weight,
           DateTime birth,
           string mobileNumber,
           Location location)
           : base(id, name, email, password)
        {
            Height = height;
            Weight = weight;
            Birth = birth;
            MobileNumber = mobileNumber;
            Location = location;
        }

        public Player(
            string name,
            string email,
            string password,
            decimal height,
            decimal weight,
            DateTime birth,
            string mobileNumber,
            Location location)
            : base(name, email, password)
        {
            Height = height;
            Weight = weight;
            Birth = birth;
            MobileNumber = mobileNumber;
            Location = location;
        }

        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }
        public DateTime Birth { get; private set; }
        public string MobileNumber { get; private set; }
        public Location Location { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsEmail(Email, "Email", "O campo e-mail deve ser do tipo e-mail.")
                .IsNotNullOrEmpty(Email, "Email", "O campo e-mail deve estar preenchido.")
                .IsNotNullOrEmpty(Password, "Senha", "O campo senha deve estar preenchido.")
                .IsNotNullOrEmpty(Name, "Nome", "O campo nome deve estar preenchido.")
                .IsLowerOrEqualsThan(0, Height, "Altura", "O campo altura deve ser maior que 0.")
                .IsLowerOrEqualsThan(0, Weight, "Peso", "O campo peso deve ser maior que 0.")
                .IsNotNull(Birth, "Data nascimento", "O campo data de nascimento deve estar preenchido.")
                .IsNotNullOrEmpty(MobileNumber, "Telefone", "O campo telefone deve estar preenchido."));
        }

        public void ApplyEncryptedPassword(string encryptedPassword)
            => Password = encryptedPassword;

        // TODO : Availability
    }
}
