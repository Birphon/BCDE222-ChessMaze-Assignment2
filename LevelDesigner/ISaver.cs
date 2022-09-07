namespace LevelDesigner
{
    public interface ISaver
    {
        void Save(string filename, IFileable callMeBackforDetails);
    }
}
