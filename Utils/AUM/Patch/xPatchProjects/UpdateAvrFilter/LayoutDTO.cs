namespace AUM.XPatch
{
    internal class LayoutDTO
    {
        internal long Id { get; set; }
        internal string Name { get; set; }
        internal byte[] ZippedSettings { get; set; }
        internal byte[] Settings { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Id);
        }
    }
}