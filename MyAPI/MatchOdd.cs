
namespace MyAPI
{
    public class MatchOdd
    {
        private int id;
        private int matchId;
        private string specifier = string.Empty;
        private decimal odd;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int MatchId
        {
            get { return matchId; }
            set { matchId = value; }
        }

        public string Specifier
        {
            get { return specifier; }
            set { specifier = value; }
        }

        public decimal Odd
        {
            get { return odd; }
            set { odd = value; }
        }

    }
}
