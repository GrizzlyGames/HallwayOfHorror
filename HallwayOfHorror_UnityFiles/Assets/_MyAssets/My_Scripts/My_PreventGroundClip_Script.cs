using UnityEngine;
using System.Collections;

public class My_PreventGroundClip_Script : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        }
	}
}
