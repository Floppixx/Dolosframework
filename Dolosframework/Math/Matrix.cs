using System;

namespace Dolosframework.Math
{
    /// <summary>
    /// A matrix.
    /// </summary>
    public class Matrix
    {
        #region VARIABLES

        private readonly float[] _data;
        private readonly int _columns, _rows;

        #endregion VARIABLES

        #region CONSTRUCTOR

        public Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _data = new float[rows * columns];
        }

        #endregion CONSTRUCTOR

        #region METHODS

        public void Read(byte[] data)
        {
            for (var y = 0; y < _rows; y++)
                for (var x = 0; x < _columns; x++)
                    this[y, x] = BitConverter.ToSingle(data, sizeof(float) * (y * _columns + x));
        }

        public byte[] ToByteArray()
        {
            const int sof = sizeof(float);
            var data = new byte[_data.Length * sof];
            for (var i = 0; i < _data.Length; i++)
                Array.Copy(BitConverter.GetBytes(_data[i]), 0, data, i * sof, sof);
            return data;
        }

        #endregion METHODS

        #region OPERANDS

        public float this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }

        public float this[int row, int column]
        {
            get { return _data[row * _columns + column]; }
            set { _data[row * _columns + column] = value; }
        }

        #endregion OPERANDS
    }
}