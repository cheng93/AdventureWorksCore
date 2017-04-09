namespace AdventureWorks.Common.Commands
{
    public class RequestSettings
    {
        public int Take { get; set; }

        public int Skip { get; set; }

        public static RequestSettings Default => new RequestSettings
        {
            Take = 1000,
            Skip = 0
        };
    }
}
