namespace ReceivingDataViaApiAndWritingToFile
{
    public class Post
    {
        public override string ToString()
        {
            return $"{UserId}\n{Id}\n{Title}\n{Body}\n\n";
        }

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}