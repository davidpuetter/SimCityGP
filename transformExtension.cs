using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityEngine.Extensions
{
    // static class to allow for the camera script to use the function
    public static class transformExtension
    {
        
        // Updates the local eulerAngles (essentially rotations) to a new vector3,
        // if a value is omitted then the old value will be used.
        public static void SetLocalEulerAngles(this Transform transform, float? x = null, float? y = null, float? z = null)
        {
            var vector = new Vector3();

            // manage current/old rotations and apply to vector
            if (x != null)
            { vector.x = x.Value; }
            else
            { vector.x = transform.localEulerAngles.x; }

            if (y != null)
            { vector.y = y.Value; }
            else
            { vector.y = transform.localEulerAngles.y; }

            if (z != null)
            { vector.z = z.Value; }
            else
            { vector.z = transform.localEulerAngles.z; }

            // update rotations
            transform.localEulerAngles = vector;
        }

    }
}
