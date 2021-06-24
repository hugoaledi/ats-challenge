namespace ATSChallenge.Domain.ConfigurationObjects
{
    public class DatabaseConfigurations
    {
        public string Connection { get; set; } = "";

        public bool Migrate { get; set; } = false;
    }
}
