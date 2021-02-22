using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlleur : MonoBehaviour
{
    public List<RawImage> weaponsImage = new List<RawImage>();
    public List<GameObject> weapons = new List<GameObject>();
    public GameObject marche;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (marche.active)
        {
            foreach (RawImage weaponImage in weaponsImage)
            {
                if (weaponImage.GetComponent<ScriptMarket>().weaponChoosen)
                {
                    foreach (GameObject weapon in weapons)
                    {
                        if (weapon.name == weaponImage.GetComponent<ScriptMarket>().weaponName)
                        {
                            if(player.transform.childCount < 3)
                            {
                                GameObject go = Instantiate(weapon);
                                go.transform.parent = player.transform;
                                go.transform.position = go.transform.position - new Vector3(2, -1, 0);
                                go.transform.Rotate(new Vector3(0,180, 0));
                                weaponImage.GetComponent<ScriptMarket>().weaponChoosen = false;
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
