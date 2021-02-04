using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int vitesse, vitesseCam;
    [SerializeField] private Animator animator;
    public Transform main;
    public Transform arme;
    [SerializeField] private Rigidbody rb;

    private Vector3 deplacement, rotation;

    private void Update()
    {
        float _mouvX = Input.GetAxisRaw("Horizontal");
        float _mouvZ = Input.GetAxisRaw("Vertical");

        // avancer et tourne peut importe la rotation
        Vector3 _mouH = transform.right * _mouvX;
        Vector3 _mouV = transform.forward * _mouvZ;

        deplacement = (_mouH + _mouV).normalized * vitesse;

        animator.SetFloat("vitesseAvancerReculer", _mouvZ);
        animator.SetFloat("vitesseDroiteGauche", _mouvX);

        float _camRotationY = 5 * Input.GetAxis("Mouse X");
        rotation = new Vector3(0, _camRotationY, 0) * vitesseCam;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + deplacement * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
}
