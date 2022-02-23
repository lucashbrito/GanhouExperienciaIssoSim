namespace GanhouExperienciaIssoSim.Domain
{
    public class Bet
    {
        public Guid Id { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
        public int Hits { get; set; }
        public List<int> RightHits { get; set; } = new List<int>();

        public string PrizeDrawName { get; set; }

        public string FormatNumbers;
        public string FormatRightHits;

        public void GetFormatNumbers(string type)
        {
            FormatNumbers = @String.Join(type, Numbers);
            FormatRightHits = @String.Join(type, RightHits);
        }

        public void SetHits(int hits)
        {
            Hits = hits;
        }

        internal void SetRightHits(List<int> rightHits)
        {
            RightHits = rightHits;
        }
    }
}