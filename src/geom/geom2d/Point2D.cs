using System;

namespace DyComposite
{
    namespace Geometry2D
    {
        public struct Point2D
        {
            public double x;
            public double y;
            public static double DistanceTo2D(Point2D pt1, Point2D pt2)
            {
                //TODO
                throw(new NotImplementedException());
            }
            public Point2D(ref Point2D origin)
            {
                this.x= origin.x;
                this.y= origin.y;
            }
            
            public Point2D(ref Point2D origin, ref Vector2D offset)
            {
               this.x = origin.x + offset.x;
               this.y = origin.y + offset.y;     
            }
        }
    }
}