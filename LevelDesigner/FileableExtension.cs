using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LevelDesigner
{
    public class FileableExtension : IFileableExtension
    {

        private Part[,] _board;

        public string Name { get; set; }

        public FileableExtension(int hight, int width)
        {
            _board = new Part[hight, width];
        }

        public FileableExtension(Part[,] aLevel)
        {
            _board = aLevel;
        }

        public int GetColumnCount()
        {
            throw new NotImplementedException();
        }

        public int GetRowCount()
        {
            throw new NotImplementedException();
        }

        public Part WhatsAt(int row, int column)
        {
            return _board[row, column];
        }

        public void SetPieceAt(Part part, int row, int column)
        {
            _board[row, column] = part;
        }
    }
}
