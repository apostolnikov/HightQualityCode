namespace IssueTracker.Entity.Post
{
    using System;
    using System.Text;

    public class Comment
    {
        private string text;
        private User author;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == null || value == string.Empty || value.Length < 2)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().AppendLine(this.Text).AppendFormat("-- {0}", this.Author.Username).AppendLine().ToString().Trim();
        }
    }
}