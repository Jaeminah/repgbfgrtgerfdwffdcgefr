namespace Synapse_X_Remake.Worker
{
    internal class SelectedFolder
    {
        public static string selectedPath = "./Scripts";

        public SelectedFolder(string selectedPath)
        {
            SelectedPath = selectedPath;
        }

        private string SelectedPath
        {
            set
            {
                selectedPath = value;
            }

            get
            {
                return selectedPath;
            }
        }
    }
}
