using System.Collections.Generic;
using UnityEngine;

public class MeshSlicer : MonoBehaviour
{
    public Collider swordCollider;

    public MeshFilter targetMeshFilter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SliceMesh(targetMeshFilter, swordCollider);
        }
    }

    public void SliceMesh(MeshFilter meshFilter, Collider sliceCollider)
    {
        Mesh originalMesh = meshFilter.mesh;
        Vector3[] vertices = originalMesh.vertices;
        int[] triangles = originalMesh.triangles;
        
        List<Vector3> newVertices = new List<Vector3>();
        List<int> newTriangles = new List<int>();
        
        // Create a new mesh for the sliced part
        Mesh newMesh = new Mesh();
        
        // Loop through each triangle and check if it intersects with the slicing collider
        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 v0 = vertices[triangles[i]];
            Vector3 v1 = vertices[triangles[i + 1]];
            Vector3 v2 = vertices[triangles[i + 2]];
            
            if (IsTriangleIntersecting(v0, v1, v2, sliceCollider))
            {
                // Handle intersection and create new vertices and triangles
                HandleSlice(v0, v1, v2, sliceCollider, newVertices, newTriangles);
            }
            else
            {
                // If the triangle does not intersect, add it to the new mesh
                AddTriangle(v0, v1, v2, newVertices, newTriangles);
            }
        }
        
        // Assign new vertices and triangles to the new mesh
        newMesh.vertices = newVertices.ToArray();
        newMesh.triangles = newTriangles.ToArray();
        
        // Recalculate normals and UVs (simple UVs for demonstration)
        newMesh.RecalculateNormals();
        newMesh.uv = GenerateSimpleUVs(newVertices);

        // Create a new GameObject for the sliced mesh
        GameObject slicedObject = new GameObject("SlicedMesh");
        MeshFilter slicedMeshFilter = slicedObject.AddComponent<MeshFilter>();
        MeshRenderer slicedMeshRenderer = slicedObject.AddComponent<MeshRenderer>();
        
        slicedMeshFilter.mesh = newMesh;
        slicedMeshRenderer.material = meshFilter.GetComponent<Renderer>().material;
        
        // Optionally, you can destroy the original object or keep it
        // Destroy(meshFilter.gameObject);
    }

    private bool IsTriangleIntersecting(Vector3 v0, Vector3 v1, Vector3 v2, Collider collider)
    {
        // Check if any of the triangle's vertices are inside the collider
        return collider.bounds.Contains(v0) || collider.bounds.Contains(v1) || collider.bounds.Contains(v2);
    }

    private void HandleSlice(Vector3 v0, Vector3 v1, Vector3 v2, Collider collider, List<Vector3> newVertices, List<int> newTriangles)
    {
        // This method should handle the actual slicing logic.
        // For simplicity, we will just create a new triangle with the original vertices.
        AddTriangle(v0, v1, v2, newVertices, newTriangles);
    }

    private void AddTriangle(Vector3 v0, Vector3 v1, Vector3 v2, List<Vector3> newVertices, List<int> newTriangles)
    {
        int index0 = newVertices.Count;
        newVertices.Add(v0);
        newVertices.Add(v1);
        newVertices.Add(v2);
        
        newTriangles.Add(index0);
        newTriangles.Add(index0 + 1);
        newTriangles.Add(index0 + 2);
    }

    private Vector2[] GenerateSimpleUVs(List<Vector3> vertices)
    {
        Vector2[] uvs = new Vector2[vertices.Count];
        
        for (int i = 0; i < vertices.Count; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z); // Simple UV mapping
        }
        
        return uvs;
    }
}