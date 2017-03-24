using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dolosframework.Math
{
    /// <summary>
    /// Class that holds information about a 3d-coordinate and offers some basic operations
    /// </summary>
    public struct Vector3
    {
        [DllImport("USER32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        public static bool IsKeyDown(int key) => GetKeyState(key) != 0;

        #region VARIABLES

        public float X;
        public float Y;
        public float Z;

        #endregion VARIABLES

        #region PROPERTIES

        /// <summary>
        /// Returns a new Vector3 at (0,0,0)
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);

        /// <summary>
        /// Returns a new Vector3 at (1,0,0)
        /// </summary>
        public static Vector3 UnitX => new Vector3(1, 0, 0);

        /// <summary>
        /// Returns a new Vector3 at (0,1,0)
        /// </summary>
        public static Vector3 UnitY => new Vector3(0, 1, 0);

        /// <summary>
        /// Returns a new Vector3 at (0,0,1)
        /// </summary>
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        #endregion PROPERTIES

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new Vector3 using the given values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new Vector3 by copying the values of the given Vector3
        /// </summary>
        /// <param name="vec"></param>
        public Vector3(Vector3 vec) : this(vec.X, vec.Y, vec.Z) { }

        /// <summary>
        /// Initializes a new Vector3 using the given float-array
        /// </summary>
        /// <param name="values"></param>
        public Vector3(IReadOnlyList<float> values) : this(values[0], values[1], values[2]) { }

        #endregion CONSTRUCTOR

        #region METHODS

        /// <summary>
        /// Returns the length of this Vector3
        /// </summary>
        /// <returns></returns>
        public float Length() => (float)System.Math.Abs(System.Math.Sqrt(System.Math.Pow(X, 2) + System.Math.Pow(Y, 2) + System.Math.Pow(Z, 2)));

        /// <summary>
        /// Returns the distance from this Vector3 to the given Vector3
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float DistanceTo(Vector3 other)
        {
            return (this - other).Length();
        }

        public override bool Equals(object obj)
        {
            var vec = (Vector3)obj;
            return GetHashCode() == vec.GetHashCode();
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        public override string ToString() => $"[X={X}, Y={Y}, Z={Z}]";

        #endregion METHODS

        #region OPERATORS

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        public static Vector3 operator *(Vector3 v1, float scalar) => new Vector3(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);

        public static bool operator ==(Vector3 v1, Vector3 v2) => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return X;

                    case 1:
                        return Y;

                    case 2:
                        return Z;

                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        X = value;
                        break;

                    case 1:
                        Y = value;
                        break;

                    case 2:
                        Z = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion OPERATORS
    }
}