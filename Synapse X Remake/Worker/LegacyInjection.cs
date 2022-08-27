using System;

namespace Synapse_X_Remake.Worker
{
    internal class LegacyInjection
    {
        public static bool legacyInjection = Convert.ToBoolean(Properties.Settings.Default["LegacyInject"].ToString());

        public LegacyInjection(bool legacyInjection)
        {
            legacyinjection = legacyInjection;
        }

        private bool legacyinjection
        {
            set
            {
                legacyInjection = value;
            }

            get
            {
                return legacyInjection;
            }
        }
    }
}
