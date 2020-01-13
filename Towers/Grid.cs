using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private float size = 1f;

    private List<Vector3> reserved = new List<Vector3>();
    private float topPlaneY = 12.5f;
    private float bottomPlaneY = 10.5f;

    public void Awake()
    {
        // first we reserve all the space on top and bottom planes then we free up the buildable areas
        ReserveSquare(new Vector3(0f, bottomPlaneY, 0f), new Vector3(500f, bottomPlaneY, 500f), bottomPlaneY); // bottom building plane
        ReserveSquare(new Vector3(0f, topPlaneY, 0f), new Vector3(500f, topPlaneY, 500f), topPlaneY); // castle(top) building plane

        //west buildable area
        FreeUpSquare(new Vector3(27f, topPlaneY, 46f), new Vector3(63f, topPlaneY, 56f), topPlaneY); // setting up buildable area around the castle(top) plane
        FreeUpSquare(new Vector3(46f, topPlaneY, 57f), new Vector3(63f, topPlaneY, 61f), topPlaneY);
        FreeUpSquare(new Vector3(46f, topPlaneY, 75f), new Vector3(63f, topPlaneY, 79f), topPlaneY);
        FreeUpSquare(new Vector3(27f, topPlaneY, 80f), new Vector3(63f, topPlaneY, 90f), topPlaneY);

        FreeUpSquare(new Vector3(67f, bottomPlaneY, 46f), new Vector3(91f, bottomPlaneY, 61f), bottomPlaneY);// setting up bottom buildable area
        FreeUpSquare(new Vector3(27f, bottomPlaneY, 75f), new Vector3(91f, bottomPlaneY, 90f), bottomPlaneY);

        //east buildable area
        FreeUpSquare(new Vector3(202f, topPlaneY, 57f), new Vector3(219f, topPlaneY, 61f), topPlaneY); // setting up buildable area around the castle(top) plane
        FreeUpSquare(new Vector3(202f, topPlaneY, 46f), new Vector3(238f, topPlaneY, 56f), topPlaneY);
        FreeUpSquare(new Vector3(202f, topPlaneY, 75f), new Vector3(219f, topPlaneY, 79f), topPlaneY);
        FreeUpSquare(new Vector3(202f, topPlaneY, 79f), new Vector3(238f, topPlaneY, 90f), topPlaneY);

        FreeUpSquare(new Vector3(174f, bottomPlaneY, 75f), new Vector3(198f, bottomPlaneY, 90f), bottomPlaneY);// setting up bottom buildable area
        FreeUpSquare(new Vector3(174f, bottomPlaneY, 46f), new Vector3(198f, bottomPlaneY, 61f), bottomPlaneY);

    }


    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        if (yCount >= 12)
        {
            yCount = 12;
        }

        if (yCount < 12)
        {
            yCount = 10;
        }

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size + 0.5f,
            (float)zCount * size);

        result += transform.position;
        return result;
    }



    public bool IsReserved(Vector3 position)
    {
        if (reserved.Contains(position))
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void FreeUpSquare(Vector3 leftbottom, Vector3 righttop, float y)
    {
        for (int x = Mathf.RoundToInt(leftbottom.x); x <= Mathf.RoundToInt(righttop.x); x++)
        {
            for (int z = Mathf.RoundToInt(leftbottom.z); z <= Mathf.RoundToInt(righttop.z); z++)
            {
                reserved.Remove(new Vector3(x, y, z));
            }
        }
    }

    public void ReserveSpace(Vector3 position)
    {
        Vector3 lefttop = new Vector3(position.x - 1f, position.y, position.z + 1f);
        Vector3 top = new Vector3(position.x, position.y, position.z + 1f);
        Vector3 righttop = new Vector3(position.x + 1f, position.y, position.z + 1f);
        Vector3 right = new Vector3(position.x + 1f, position.y, position.z);
        Vector3 rightbottom = new Vector3(position.x + 1f, position.y, position.z - 1f);
        Vector3 bottom = new Vector3(position.x, position.y, position.z - 1f);
        Vector3 leftbottom = new Vector3(position.x - 1f, position.y, position.z - 1f);
        Vector3 left = new Vector3(position.x - 1f, position.y, position.z);
        reserved.Add(position);
        reserved.Add(lefttop);
        reserved.Add(top);
        reserved.Add(righttop);
        reserved.Add(right);
        reserved.Add(rightbottom);
        reserved.Add(bottom);
        reserved.Add(leftbottom);
        reserved.Add(left);
    }


    private void ReserveSquare(Vector3 leftbottom, Vector3 righttop, float y)    
    {
        for (int x = Mathf.RoundToInt(leftbottom.x); x <= Mathf.RoundToInt(righttop.x); x++)
        {
            for (int z = Mathf.RoundToInt(leftbottom.z); z <= Mathf.RoundToInt(righttop.z); z++)
            {
                reserved.Add(new Vector3(x, y, z));
            }
        }
    }

    


    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(float x = 0; x < 40; x += size)
        {
            for(float z = 0; z < 40; z+= size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }*/

}
