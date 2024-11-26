using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSlicer : MonoBehaviour
{
    // void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
    //     {
    //         Debug.Log("Slicing")
    //         Slice(collision.gameObject, gameObject);
    //     }
    // }

    public GameObject target;

    void Start()
    {
        target = GameObject.Find("Cube");
    }

    void Update()
    {
        Slice(target, gameObject);
    }
     public void Slice(GameObject targetObject, GameObject slicingObject)
    {
        // Step 1: Get target mesh
        MeshFilter meshFilter = targetObject.GetComponent<MeshFilter>();
        Mesh targetMesh = meshFilter.mesh;

        Vector3[] vertices = targetMesh.vertices;
        int[] triangles = targetMesh.triangles;
        Vector2[] uvs = targetMesh.uv;

        // Step 2: Define slicing plane
        Plane slicingPlane = new Plane(
            slicingObject.transform.up, 
            slicingObject.transform.position
        );

        // Step 3: Initialize new mesh data
        List<Vector3> newVertices = new List<Vector3>();
        List<int> newTriangles = new List<int>();
        List<Vector2> newUVs = new List<Vector2>();

        // Step 4: Process triangles
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int indexA = triangles[i];
            int indexB = triangles[i + 1];
            int indexC = triangles[i + 2];

            Vector3 vA = vertices[indexA];
            Vector3 vB = vertices[indexB];
            Vector3 vC = vertices[indexC];

            Vector2 uvA = uvs[indexA];
            Vector2 uvB = uvs[indexB];
            Vector2 uvC = uvs[indexC];

            bool sideA = slicingPlane.GetSide(vA);
            bool sideB = slicingPlane.GetSide(vB);
            bool sideC = slicingPlane.GetSide(vC);

            if (sideA == sideB && sideB == sideC)
            {
                // All vertices on the same side
                AddTriangle(newVertices, newTriangles, newUVs, vA, vB, vC, uvA, uvB, uvC);
            }
            else
            {
                // Triangle intersects the plane; split it
                SplitTriangle(slicingPlane, vA, vB, vC, uvA, uvB, uvC, sideA, sideB, sideC, newVertices, newTriangles, newUVs);
            }
        }

        // Step 5: Update the mesh
        Mesh newMesh = new Mesh();
        newMesh.vertices = newVertices.ToArray();
        newMesh.triangles = newTriangles.ToArray();
        newMesh.uv = newUVs.ToArray();
        newMesh.RecalculateNormals();
        meshFilter.mesh = newMesh;

        Debug.Log("Slicing complete!");
    }

    private void AddTriangle(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, 
                              Vector3 vA, Vector3 vB, Vector3 vC, 
                              Vector2 uvA, Vector2 uvB, Vector2 uvC)
    {
        int startIndex = vertices.Count;
        vertices.Add(vA);
        vertices.Add(vB);
        vertices.Add(vC);
        uvs.Add(uvA);
        uvs.Add(uvB);
        uvs.Add(uvC);
        triangles.Add(startIndex);
        triangles.Add(startIndex + 1);
        triangles.Add(startIndex + 2);
    }

    private void SplitTriangle(Plane plane, Vector3 vA, Vector3 vB, Vector3 vC,
                               Vector2 uvA, Vector2 uvB, Vector2 uvC,
                               bool sideA, bool sideB, bool sideC,
                               List<Vector3> newVertices, List<int> newTriangles, List<Vector2> newUVs)
    {
        // Handle splitting the triangle and adding new geometry
        Debug.LogWarning("SplitTriangle logic is not fully implemented in this example.");
    }
}
