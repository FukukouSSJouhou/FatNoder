namespace RCBuilderTasks
{
    public class RCBuilder:Microsoft.Build.Utilities.Task
    {
        [Microsoft.Build.Framework.Required]
        public Microsoft.Build.Framework.ITaskItem RCFile { get; set; }
        [Microsoft.Build.Framework.Output]
        public string OutResFile { get; set; }
        public override bool Execute()
        {
            return true;

        }
    }
}