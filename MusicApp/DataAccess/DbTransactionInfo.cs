namespace MusicApp.DataAccess
{
    public struct DbTransactionInfo
    {
        public bool Succeeded { get; set; }
        public IList<string> Errors { get; set; }
    }
}