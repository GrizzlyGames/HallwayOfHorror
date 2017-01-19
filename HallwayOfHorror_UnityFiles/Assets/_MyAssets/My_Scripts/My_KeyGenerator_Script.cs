using UnityEngine;
using System.Collections;

public class My_KeyGenerator_Script : MonoBehaviour {

    public GameObject Key_Container;

    public GameObject[] keys_Array;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    Vector3 GetRandomPosition()
    {
        float X = Random.Range(minX, maxX);
        float Y = 2;
        float Z = Random.Range(minZ, maxZ);

        return new Vector3(X, Y, Z);
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < keys_Array.Length; i++)
        {
            GameObject go = Instantiate(keys_Array[i], GetRandomPosition(), Random.rotation) as GameObject;
            go.transform.parent = Key_Container.transform;
        }
	}
}
