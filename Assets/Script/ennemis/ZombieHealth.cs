using UnityEngine;


public class ZombieHealth : MonoBehaviour
{
    public int vie;
    public GameObject[] loot;
    private Vector3 posZombie;
    
    private void Awake()
    {
        vie = 20;
    }

    // Update is called once per frame
    void Update()
    {
        posZombie = transform.position;
        
        if (vie <= 0)
        {
            lootitem();
            Destroy(gameObject);
        }
    }

    void lootitem()
    {
        foreach(GameObject Item in loot)
        {
            int i = Random.Range(1, 100);
            if (i <= 10) Instantiate(Item,posZombie, Quaternion.identity);
        }
    }
}
