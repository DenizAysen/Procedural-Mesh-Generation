using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PyramidMaker : MonoBehaviour
{
    public float pyramidSize = 5f;

    void Update()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshBuilder meshBuilder = new MeshBuilder(4);

        Vector3 top = new Vector3(0, pyramidSize, 0);

        Vector3 base0 = Quaternion.AngleAxis(0f, Vector3.up) * Vector3.forward * pyramidSize;

        Vector3 base1 = Quaternion.AngleAxis(240f, Vector3.up) * Vector3.forward * pyramidSize;

        Vector3 base2 = Quaternion.AngleAxis(120f, Vector3.up) * Vector3.forward * pyramidSize;

        meshBuilder.BuildTriangle(base0, base1, base2, 0);
        meshBuilder.BuildTriangle(base1, base0, top, 1);
        meshBuilder.BuildTriangle(base2, top, base0, 2);
        meshBuilder.BuildTriangle(top, base2, base1, 3);

        meshFilter.mesh = meshBuilder.CreateMesh();
    }
}
