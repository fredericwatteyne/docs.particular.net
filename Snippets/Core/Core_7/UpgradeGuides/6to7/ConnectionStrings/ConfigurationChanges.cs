namespace Core7.UpgradeGuides._6to7.ConnectionStrings
{
    using System.Configuration;
    using NServiceBus;

    public class ConfigurationChanges
    {

        void ProvideConfiguration(TransportExtensions<LearningTransport> transport)
        {
            #region 6to7ConnectionStrings
            var connectionString = ConfigurationManager.ConnectionStrings["theConnectionName"].ConnectionString;
            transport.ConnectionString(connectionString);
            #endregion
        }
    }
}