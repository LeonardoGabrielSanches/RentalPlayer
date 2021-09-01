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
           string id,
           string name,
           string email,
           string password,
           string description,
           decimal height,
           decimal weight,
           DateTime birth,
           string mobileNumber,
           Location location,
           string avatarUrl)
           : base(id, name, email, password, avatarUrl)
        {
            Description = description;
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
            string description,
            decimal height,
            decimal weight,
            DateTime birth,
            string mobileNumber,
            Location location,
            string avatarUrl)
            : base(name, email, password, avatarUrl)
        {
            Description = description;
            Height = height;
            Weight = weight;
            Birth = birth;
            MobileNumber = mobileNumber;
            Location = location;

            Validate();
        }

        public Player(string email, string password) : base(email, password)
        {
        }

        public string Description { get; private set; }
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
                .IsNotNullOrEmpty(Description, "Descrição", "O campo descrição deve estar preenchido.")
                .IsLowerOrEqualsThan(0, Height, "Altura", "O campo altura deve ser maior que 0.")
                .IsLowerOrEqualsThan(0, Weight, "Peso", "O campo peso deve ser maior que 0.")
                .IsNotNull(Birth, "Data nascimento", "O campo data de nascimento deve estar preenchido.")
                .IsNotNullOrEmpty(MobileNumber, "Telefone", "O campo telefone deve estar preenchido."));
        }

        public void ApplyEncryptedPassword(string encryptedPassword)
            => Password = encryptedPassword;

        public void Update(string name,
                           string email,
                           string description,
                           decimal height,
                           decimal weight,
                           DateTime birth,
                           string mobileNumber,
                           Location location,
                           string avatarUrl)
        {
            Name = name;
            Email = email;
            Description = description;
            Height = height;
            Weight = weight;
            Birth = birth;
            MobileNumber = mobileNumber;
            Location = location;
            AvatarUrl = avatarUrl;

            Validate();
        }

        public int CalculateAge()
        {
            var dateTimeNow = DateTime.Now;

            var age = dateTimeNow.Year - Birth.Year;

            if (dateTimeNow.Month > Birth.Month)
                age++;

            return age;
        }


        // TODO : Availability
    }
}
