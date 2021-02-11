using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptMarket : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Material onOverMaterial;
    // Start is called before the first frame update
    void Start()
    {
        onOverMaterial = Resources.Load<Material>("Material/WeaponShopBackgroundOnOver");
    }

    public void OnPointerEnter(PointerEventData e)
    {
        Debug.Log("Mouse Enter");
        Debug.Log(GetComponent<RawImage>().IsActive());
        GetComponent<RawImage>().enabled = true;
    }

    public void OnPointerExit(PointerEventData e)
    {
        Debug.Log("Mouse Exit");
        GetComponent<RawImage>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
