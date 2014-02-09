using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideScroller
{   
    class CollisionDetector : List<BoardElement>
    {
        public bool CheckForCollision()
        {
            for (int i = 0; i< this.Count; i++)
            {
                var e1 = this[i];

                for (int j = 0; j < this.Count; j++)
                {
                    bool yCollision = false;
                    bool xCollision = false;

                    if (i == j)
                    {
                        continue;
                    }
                    var e2 = this[j];

                    double e1Bottom = e1.Position.Y + e1.Height;
                    double e1Top = e1.Position.Y;
                    double e2Bottom = e2.Position.Y + e2.Height;
                    double e2Top = e2.Position.Y;

                    double e1Right = e1.Position.X + e1.Width;
                    double e1Left = e1.Position.X;
                    double e2Right = e2.Position.X + e2.Width;
                    double e2Left = e2.Position.X;

                    if (e1Bottom > e2Top && e1Bottom < e2Bottom)
                    {
                        yCollision = true;
                    }

                    if (e2Right > e1Left && e2Right < e1Right)
                    {

                        xCollision = true;
                    }

                    if (yCollision && xCollision)
                    {
                        return false;
                    }
                    Debug.Print(string.Format("Y Collision: {0}, X Collision: {1}, e1Right: {2}, e1Left: {3}, e2Right: {4}, e2Left: {5}"
                        , yCollision, xCollision, e1Right, e1Left, e2Right, e2Left));
                }
            }
            return false;
        }
    }
}
