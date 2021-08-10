using System;

namespace Test
{
    class Vector2D
    {
        public double X, Y;
        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }


        public static Vector2D operator +(Vector2D vector1, Vector2D vector2) => new(vector1.X + vector2.X, vector1.Y + vector2.Y);
        public static Vector2D operator -(Vector2D vector1, Vector2D vector2) => new(vector1.X - vector2.X, vector1.Y - vector2.Y);
        public static Vector2D operator *(Vector2D vector, double scalar) => new(vector.X * scalar, vector.Y * scalar);
        public static Vector2D operator /(Vector2D vector, double scalar) => new(vector.X / scalar, vector.Y / scalar);
        public static double operator *(Vector2D vector1, Vector2D vector2) => (vector1.X * vector2.X + vector1.Y * vector2.Y);


        public double Length => (double)Math.Sqrt(X * X + Y * Y);

        //
        // Сводка:
        //     Returns sin of angles between this vector and another.
        public double Angle(Vector2D vector2) => (this * vector2) / ((this.Length) * (vector2.Length));
        public static double Angle(Vector2D vector1, Vector2D vector2) => (vector1 * vector2) / ((vector1.Length) * (vector2.Length));
        public double Heading() => (double)-(Math.Atan2(0, 1) - Math.Atan2(Y, X));
        public Vector2D Normalized => this * (1 / Length);
        public void SetLength(double Length)
        {
            Vector2D tmp = this.Normalized;
            this.X = tmp.X *= Length;
            this.Y = tmp.Y *= Length;
        }


        public void Normalize()
        {
            this.X = this.Normalized.X;
            this.Y = this.Normalized.Y;
        }


    }

    class Vector2F
    {
        public float X, Y;
        public Vector2F(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }


        public static Vector2F operator +(Vector2F vector1, Vector2F vector2) => new(vector1.X + vector2.X, vector1.Y + vector2.Y);
        public static Vector2F operator -(Vector2F vector1, Vector2F vector2) => new(vector1.X - vector2.X, vector1.Y - vector2.Y);
        public static Vector2F operator *(Vector2F vector, float scalar) => new(vector.X * scalar, vector.Y * scalar);
        public static Vector2F operator /(Vector2F vector, float scalar) => new(vector.X / scalar, vector.Y / scalar);
        public static float operator *(Vector2F vector1, Vector2F vector2) => (vector1.X * vector2.X + vector1.Y * vector2.Y);


        public float Length => (float)Math.Sqrt(X * X + Y * Y);

        //
        // Сводка:
        //     Returns sin of angles between this vector and another.
        public float Angle(Vector2F vector2) => (this * vector2) / ((this.Length) * (vector2.Length));
        public static float Angle(Vector2F vector1, Vector2F vector2) => (vector1 * vector2) / ((vector1.Length) * (vector2.Length));
        public float Heading() => (float)-(Math.Atan2(0, 1) - Math.Atan2(Y, X));
        public Vector2F Normalized => this * (1 / Length);
        public void SetLength(float Length)
        {
            Vector2F tmp = this.Normalized;
            this.X = tmp.X *= Length;
            this.Y = tmp.Y *= Length;
        }


        public void Normalize()
        {
            this.X = this.Normalized.X;
            this.Y = this.Normalized.Y;
        }


    }

}