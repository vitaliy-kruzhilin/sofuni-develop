namespace RentVacation.Dealers.Data
{
    public class DataConstants
    {
        public class Category
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }

        public class Options
        {
            public const int MinNumberOfBeds = 2;
            public const int MaxNumberOfBeds = 50;
        }

        public class Dealer
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class Apartament
        {
            public const int MinInformationLength = 2;
            public const int MaxInformationLength = 20;
        }
    }
}
