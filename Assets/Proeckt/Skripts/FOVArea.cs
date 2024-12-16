using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FOVArea : MonoBehaviour
{
    [SerializeField] private float distance = 30f;
    [SerializeField] private float angleBound = 30f;
    [SerializeField] private int pointsResolution = 8;
    public UnityEvent target;
    public bool active;
    public AudioClip clip;
    private float radiansAngleBound;
    private MeshFilter meshFilter;

    void Start()
    {
        radiansAngleBound = angleBound * Mathf.Deg2Rad;
        meshFilter = GetComponent<MeshFilter>();
        StartCoroutine(Check());
    }


    IEnumerator Check()
    {
        while (true)
        {
            CreateFOVArea();
            yield return new WaitForSeconds(.18f);
        }
    }


    void CreateFOVArea()
    {
        meshFilter.mesh = CreateMesh(FindPoints());

    }

    private Vector3[] FindPoints()
    {
        Vector3[] pointsTemp = new Vector3[pointsResolution];
        for (int i = 0; i < pointsTemp.Length; i++)
        {
            pointsTemp[i] = DoneRayCast(radiansAngleBound * (((float)i / 4) - 1));
        }
        return pointsTemp;
    }


    Vector3 DoneRayCast(float angleTemp)
    {
        Vector3 rayDirection = new Vector3(Mathf.Sin(angleTemp), 0, Mathf.Cos(angleTemp));
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(rayDirection), out hit, distance))
        {
            if (hit.collider.tag == "Player")
            {
                if (active) 
                {
                    SoundPlayer.regit.Play(clip);
                    target.Invoke();
                    active = false;
                }
                
            }
            return rayDirection * hit.distance;
        }
        else
        {
            return rayDirection * distance;
        }
    }

    Mesh CreateMesh(Vector3[] pointsTemp)
    {
        Mesh meshTemp = new Mesh
        {
            name = "FOVMesh"
        };


        Vector3[] verticesArray = new Vector3[pointsTemp.Length + 1];
        verticesArray[0] = Vector3.zero;
        for (int i = 1; i < verticesArray.Length; i++)
        {
            verticesArray[i] = pointsTemp[i - 1];
        }
        meshTemp.vertices = verticesArray;


        int[] trianglesArray = new int[3 * (pointsTemp.Length - 1)];
        for (int i = 0; i < trianglesArray.Length; i++)
        {
            if (i % 3 == 0)
            {
                trianglesArray[i] = 0;
            }
            else
            {
                trianglesArray[i] = i - 2 * (i / 3);
            }
        }
        meshTemp.triangles = trianglesArray;


        return meshTemp;
    }

}
