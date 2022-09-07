using System;
using System.Collections.Generic;
using System.Text;

namespace LevelDesigner
{
    class Saver : ISaver
    {
        public void Save(string filename, IFileable callMeBackforDetails)
        {
            // Intentionally not implemented
        }

        public void Save(string filename, IFileableExtension callMeBackforDetails)
        {
            throw new NotImplementedException();
        }
    }
}
