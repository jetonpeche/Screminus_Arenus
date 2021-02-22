using UnityEngine;

public class RamasserObjet : MonoBehaviour
{
    [SerializeField] private float vitesseRotation;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, vitesseRotation, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            switch (other.transform.tag)
            {
                case "argent":
                    break;

                case "soin":
                    break;

                case "munition":
                    break;
            }

            Destroy(gameObject);
        }
    }
}
