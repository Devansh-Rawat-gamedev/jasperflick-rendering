using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationtransformation : transformation
{
    public Vector3 rotation;

    public override Vector3 apply(Vector3 point)
    {

        float radz = rotation.z * Mathf.Deg2Rad;
        float sinz = Mathf.Sin(radz);
        float cosz = Mathf.Cos(radz);


        return new Vector3(point.x * cosz - point.y * sinz,
            point.x * sinz + point.y * cosz,
            point.z) ;
    }
}
