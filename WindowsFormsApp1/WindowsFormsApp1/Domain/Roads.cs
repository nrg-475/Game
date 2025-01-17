﻿using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class Roads
    {
        private RoadPattern UpperRoad { get; set; }
        private RoadPattern MiddleRoad { get; set; }
        private RoadPattern LowerRoad { get; set; }
        public readonly RoadPattern[] RoadsArray;
        private const int PictureHeight = 1000;
        private static readonly int ClientHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height;

        #region Contrustors

        private Roads(Point location1, Point location2, Point location3)
        {
            (UpperRoad, MiddleRoad, LowerRoad) =
            (
               new RoadPattern(location1),
                new RoadPattern(location2),
                new RoadPattern(location3)
            );
            RoadsArray = new[] {UpperRoad, MiddleRoad, LowerRoad};
        }

        private Roads(int middleRoadY) : this(
            new(0, middleRoadY - PictureHeight), 
            new(0, 0),
            new(0, middleRoadY + PictureHeight))
        { }

        public Roads() : this(0)
        {
        }

        #endregion
        
        public void ShiftDown(int dy)
        {   
            MiddleRoad.Location = (new Point(0, MiddleRoad.Location.Y+dy));
            RefreshLocations();
        }

        private void RefreshLocations()
        {
            if (LowerRoad.Location.Y > ClientHeight+100)
            {
                LowerRoad.Location = (new Point(0,MiddleRoad.Location.Y-PictureHeight));
                (UpperRoad, MiddleRoad, LowerRoad) = (LowerRoad, UpperRoad, MiddleRoad);
            }
            UpperRoad.Location = (new Point(0,MiddleRoad.Location.Y-PictureHeight));
            LowerRoad.Location = (new Point(0,MiddleRoad.Location.Y+PictureHeight));
        }
    }
}