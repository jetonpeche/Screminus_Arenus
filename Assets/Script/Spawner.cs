using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    #region SingleTone
    public static Spawner instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private float range = 10.0f;
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private int nbMonstreMax;
    [SerializeField] private int manche = 1;
    [SerializeField] private int nbMonstreAspawn = 10;

    private int nbMonstreMap = 0;
    private int nbMonstreDerniereManche;
    private int nbMonstreAtuer, nbMonstreTuer;
    private bool finManche = false;

    public int NbMonstreTuer { get => nbMonstreTuer; private set => nbMonstreTuer = value; }

    private void Start()
    {
        nbMonstreDerniereManche = nbMonstreAtuer = nbMonstreAspawn;
    }

    private void Update()
    {
        if (finManche)
            return;

        // test
        if(Input.GetMouseButtonDown(0) && !finManche)
        {
            Destroy(GameObject.FindGameObjectWithTag("Finish"));

            EnnemiTuer();
        }

        // fin de la manche
        if(nbMonstreAspawn == 0 && nbMonstreAtuer == 0)
        {
            finManche = true;

            // test
            // MancheSuivante();
        }

        // controle le nombre ennemi sur la map
        if (nbMonstreMap < nbMonstreMax && nbMonstreAspawn > 0)
        {
            // spawn sur le navMesh quand il a trouve un espace sur celui ci
            Vector3 _point;
            if (RandomPoint(transform.position, range, out _point))
            {
                nbMonstreMap++;
                nbMonstreAspawn--;

                Instantiate(prefab, _point, Quaternion.identity);
            }
        }
    }

    public void EnnemiTuer()
    {
        nbMonstreMap--;
        nbMonstreAtuer--;
        NbMonstreTuer++;
    }

    public void MancheSuivante()
    {
        manche++;
        nbMonstreAspawn = nbMonstreDerniereManche + nbMonstreDerniereManche / 2;
        nbMonstreAtuer = nbMonstreAspawn;
        nbMonstreDerniereManche = nbMonstreAspawn;

        finManche = false;
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        // cherche une place dispo sur le navMesh
        for (int i = 0; i < 30; i++)
        {
            Vector3 _randomPoint = center + Random.insideUnitSphere * range;

            NavMeshHit _hit;
            if (NavMesh.SamplePosition(_randomPoint, out _hit, 1.0f, NavMesh.AllAreas))
            {
                result = _hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
}
