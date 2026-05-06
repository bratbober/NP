namespace _004_BroadcastChat
{
    public class MyMessage
    {
        public string ComputerName { get; set; } = SystemInformation.ComputerName;

        public bool IsOnline { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return ComputerName;
        }

    }
}
