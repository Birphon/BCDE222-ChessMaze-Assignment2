namespace LevelDesigner
{

    public interface IFileableExtension : IFileable
    {
        // Property declaration:
        public string Name
        {
            get; set;
        }

        public void SetPieceAt(Part part, int row, int column);
    }
}
