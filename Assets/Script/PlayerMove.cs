using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public Transform main;
    public Transform arme;

    // Start is called before the first frame update
    void Start()
    {
        arme.parent = main;
        arme.position = main.position;

        //arme.rotation = new Quaternion(0, 0, 0, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        float _mouvX = Input.GetAxisRaw("Horizontal");
        float _mouvZ = Input.GetAxisRaw("Vertical");

        Vector3 _deplacement = new Vector3(_mouvX, 0, _mouvZ).normalized;

        animator.SetFloat("vitesseAvancerReculer", _mouvZ);
        animator.SetFloat("vitesseDroiteGauche", _mouvX);

        transform.Translate(_deplacement * 5 * Time.deltaTime);

        float x = 5 * Input.GetAxis("Mouse X");
        transform.Rotate(0, x, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("estMort");
        }
    }
}
