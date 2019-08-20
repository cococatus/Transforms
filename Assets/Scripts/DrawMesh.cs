using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    private int width = 1;
    private int height = 1;
    private void Start()
    {
        mesh = new Mesh();
        
        var vertices = new Vector3[4];
        
        vertices[0] = new Vector3(-width, -height);
        vertices[1] = new Vector3(-width, height);
        vertices[2] = new Vector3(width, height);
        vertices[3] = new Vector3(width, -height);

        mesh.vertices = vertices;
        
        mesh.triangles = new int[]{0,1,2,0,2,3};

        var meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        gameObject.AddComponent<MeshRenderer>();

//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        mesh = sphere.GetComponent<MeshFilter>().mesh;
    }

    public void Update() {
        
        // will make the mesh appear in the Scene at origin position
//        Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, 0);
    }
}
