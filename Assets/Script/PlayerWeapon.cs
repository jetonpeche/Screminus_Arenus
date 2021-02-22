using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //public Transform hand;
    //public GameObject weapon;
    public GameObject box;
    public GameObject marche;
    GameObject hitObject;

    float remainingDistance;
    float remainingDistanceOnOpen;
    bool boxAndMarketActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deplacement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += deplacement.normalized * 5f * Time.deltaTime;
        Ray rayon = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(rayon, out hit, Mathf.Infinity))
        {
            ///Debug.Log(hit.collider.name);
            remainingDistance = hit.distance;
            if (hit.collider.name == "Boite")
            {
                hitObject = hit.transform.gameObject;
                hitObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if (hitObject != null)
                {
                    hitObject.GetComponent<Outline>().enabled = false;
                    //hitObject = null;
                }
            }
        }

        //Debug.Log(remainingDistance);
        Animator anim = box.GetComponent<Animator>();
        if (remainingDistance < 3)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetFloat("Direction", 1);
                anim.Play("OpenBox", -1, float.NegativeInfinity);
                marche.active = true;
                boxAndMarketActive = true;
                Debug.Log(Vector3.Distance(transform.position, box.transform.position));
                remainingDistanceOnOpen = remainingDistance;
            }
        }
        if (boxAndMarketActive == true && Vector3.Distance(transform.position, box.transform.position) > 2)
        {
            Debug.Log("Boite fermé");
            marche.active = false;
            anim.SetFloat("Direction", -1);
            anim.Play("OpenBox", -1, float.NegativeInfinity);
            boxAndMarketActive = false;
        }
    }
}
