﻿using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class HitBox
    {
        private readonly int difference;
        private Rectangle box;
        public Point Location => box.Location;

        public HitBox(Car car) : this(car, 0)
        {
        }

        private HitBox(Car car, int difference)
        {
            this.difference = difference;
            box = new Rectangle(car.Location.X + difference, car.Location.Y + difference, car.Image.Width - difference,
                car.Image.Height - difference);
        }

        public bool IsCollide(HitBox otherHitbox) => box.IntersectsWith(otherHitbox.box);

        public void Refresh(int dx, int dy)
        {
            box.Location = new Point(box.Location.X+dx, box.Location.Y+dy);
        }
    }
}