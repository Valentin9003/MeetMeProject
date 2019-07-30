namespace MeetMe.Data
{
    public static class DataConstants
    {
        public const string MessageMaxLengthErrorMessage = "Message can't be longer than 5000 characters.";
        public const string PictureDescriptionMaxLengthErrorMessage = "The description can't be longer than 100 characters.";
        public const string UserFirstNameMaxLengthErrorMessage = "First name can't be longer than 20 characters.";
        public const string UserLastNameMaxLengthErrorMessage = "Last name can't be longer than 20 characters.";
        public const string UserBiographyMaxLengthErrorMessage = "The filed BIOGRAPHY can't be longer than 500 characters.";
        public const string UserWeightRangeErrorMessage = "The weight is in the range of 1 to 500.";
        public const string UserHeightRangeErrorMessage = "The height is in the range of 1,00 to 2,50 with a 2-digit precision.";
    }
}
