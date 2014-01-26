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
                    if (i == j)
                    {
                        continue;
                    }
                    var e2 = this[j];

                    double e1Bottom = e1.Position.Y + e1.Height;
                    double e1Top = e1.Position.Y;
                    double e2Bottom = e2.Position.Y + e2.Height;
                    double e2Top = e2.Position.Y;

                    if (e1Bottom > e2Top && e1Bottom < e2Bottom)
                    {
                        return true;
                    } 
                    

                }
            }
            return false;
        }
    }
}
