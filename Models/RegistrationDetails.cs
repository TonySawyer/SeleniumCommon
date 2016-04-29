namespace UITest.RegressionCommon.Models
{
    /// <summary>
    /// The registration details.
    /// </summary>
    public class RegistrationDetails
    {
        /// <summary>
        /// Gets or sets the secret question value.
        /// </summary>
        public string SecretQuestionValue { get; set; }

        /// <summary>
        /// Gets or sets the secret answer.
        /// </summary>
        public string SecretAnswer { get; set; }

        /// <summary>
        /// Gets or sets the title value.
        /// </summary>
        public string TitleValue { get; set; }

        /// <summary>
        /// Gets or sets the forename.
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the gender value.
        /// </summary>
        public string GenderValue { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the business phone.
        /// </summary>
        public string BusinessPhone { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        public LoginCredentials Credentials { get; set; }
    }
}