using System.Collections;

using UnityEngine;
using System.Collections.Generic;

public class renderpoints : MonoBehaviour
{
    [SerializeField]Transform prefab;
    public int resolution = 10;
    Transform[] grid;

    

    List<transformation> transformations;
    void Awake()
    {
        grid = new Transform[(int)Mathf.Pow(resolution, 3)];

        for (int x = 0,i=0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                for (int z = 0; z < resolution; z++,i++)
                {
                    grid[i]=creategrid(x,y,z);
                    
                }
            }
        }
        
        transformations = new List<transformation>();
    }
    

    private void Update()
    {
        GetComponents<transformation>(transformations);
        for (int x = 0,i=0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                for (int z = 0; z < resolution; z++,i++)
                {
                    grid[i].localPosition = TransformPoint(x,y,z);
                }
            }
        }
    }

    Vector3 TransformPoint(int x,int y,int z)
    {
        Vector3 coord = getcoords(x, y, z);

        for (int i = 0; i < transformations.Count; i++)
        {
            coord = transformations[i].apply(coord);
        }

        return coord;
    }
    Transform creategrid(int x,int y,int z)
    {
        Transform point = Instantiate<Transform>(prefab);
        point.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        point.localPosition = getcoords(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color((float)x / resolution, (float)y / resolution, (float)z / resolution);
        return point;
    }

    Vector3 getcoords(int x,int y,int z)
    {
        Vector3 cord=Vector3.zero;

        cord = new Vector3(x-(resolution-1)*0.5f, y - (resolution - 1) * 0.5f, z - (resolution - 1) * 0.5f);

        return cord;
    }
}
