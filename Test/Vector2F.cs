namespace Test
{
    using System;
    using SFML.System;

    internal class Vector2F
    {
        private float x;
        private float y;

        public Vector2F(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float Length => (float)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));

        public Vector2F Normalized => this * (1 / this.Length);

        public float X { get => this.x; set => this.x = value; }

        public float Y { get => this.y; set => this.y = value; }

        public static Vector2F operator -(Vector2F vector1, Vector2F vector2) => new (vector1.X - vector2.X, vector1.Y - vector2.Y);

        public static Vector2F operator *(Vector2F vector, float scalar) => new (vector.X * scalar, vector.Y * scalar);

        public static Vector2F operator /(Vector2F vector, float scalar) => new (vector.X / scalar, vector.Y / scalar);

        public static float operator *(Vector2F vector1, Vector2F vector2) => (vector1.X * vector2.X) + (vector1.Y * vector2.Y);

        public static Vector2F operator +(Vector2F vector1, Vector2F vector2) => new (vector1.X + vector2.X, vector1.Y + vector2.Y);

        public static float Angle(Vector2F vector1, Vector2F vector2) => (vector1 * vector2) / (vector1.Length * vector2.Length);

        // Сводка:
        //     Returns sin of angles between this vector and another.
        public float Angle(Vector2F vector2) => (this * vector2) / (this.Length * vector2.Length);

        public float Heading() => (float)-(Math.Atan2(0, 1) - Math.Atan2(this.Y, this.X));

        public void SetLength(float length)
        {
            Vector2F tmp = this.Normalized;
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