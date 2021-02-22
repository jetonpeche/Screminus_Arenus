using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawWireCube(transform.position, new Vector3(2.01f, 2.2f, 4.01f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
