using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class ScriptMarket : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Material onOverMaterial;
    public bool weaponChoosen = false;
    public string weaponName;
    // Start is called before the first frame update
    void Start()
    {
        weaponName = this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
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

    public void OnPointerClick(PointerEventData e)
    {
        Debug.Log(weaponName);
        weaponChoosen = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
