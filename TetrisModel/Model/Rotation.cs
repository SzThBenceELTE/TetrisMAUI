using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public enum Rotation
    {
        ZERO,
        NINETY,
        ONEEIGHTY,
        TWOSEVENTY

            
    }

    public class RotationFunctions
    {
        public static int rotationValue(Rotation r)
        {
            switch(r)
            {
                case Rotation.ZERO:
                    return 0;
                    
                case Rotation.NINETY:
                    return 1;
                    
                case Rotation.ONEEIGHTY:
                    return 2;
                    
                default:
                    return 3;
                    
            }
        }
    }
}
