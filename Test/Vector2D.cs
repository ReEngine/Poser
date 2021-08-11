namespace Test
{
    using System;
    using SFML.System;

    internal class Vector2D
    {
        private double x;
        private double y;

        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Length => (double)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));

        public Vector2D Normalized => this * (1 / this.Length);

        public double X { get => this.x; set => this.x = value; }

        public double Y { get => this.y; set => this.y = value; }

        public static implicit operator Vector2f(Vector2D v) => new ((float)v.X, (float)v.Y);

        public static Vector2D operator +(Vector2D vector1, Vector2D vector2) => new (vector1.X + vector2.X, vector1.Y + vector2.Y);

        public static Vector2D operator -(Vector2D vector1, Vector2D vector2) => new (vector1.X - vector2.X, vector1.Y - vector2.Y);

        public static Vector2D operator *(Vector2D vector, double scalar) => new (vector.X * scalar, vector.Y * scalar);

        public static Vector2D operator /(Vector2D vector, double scalar) => new (vector.X / scalar, vector.Y / scalar);

        public static double operator *(Vector2D vector1, Vector2D vector2) => (vector1.X * vector2.X) + (vector1.Y * vector2.Y);

        public static Vector2D operator /(Vector2D vector1, Vector2u vector2) => new (vector1.X / vector2.X, vector1.Y / vector2.Y);

        public static double Angle(Vector2D vector1, Vector2D vector2) => (vector1 * vector2) / (vector1.Length * vector2.Length);

        // Сводка:
        //     Returns sin of angles between this vector and another.
        public double Angle(Vector2D vector2) => (this * vector2) / (this.Length * vector2.Length);

        public double Heading() => (double)-(Math.Atan2(0, 1) - Math.Atan2(this.Y, this.X));

        public void SetLength(double length)
        {
            Vector2D tmp = this.Normalized;
            this.X = tmp.X *= length;
            this.Y = tmp.Y *= length;
        }

        public void Normalize()
        {
            this.X = this.Normalized.X;
            this.Y = this.Normalized.Y;
        }
    }
}