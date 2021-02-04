using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float p_life;
    public float p_armor; // En % - 10% d'armure donne des dégâts à 90%
    //Get life bar / text
    //Get armor bar / text
    public float p_maxLife;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerLife();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayerDamaged(float damage)
    {
        if (damage - p_armor > 0)
        {
            p_life -= damage * 1- p_armor;
            UpdatePlayerLife();
            //Animation de dégâts ? (Passage rapide en rouge)

            if (p_life <= 0)
            {
                PlayerDeath();
            }
        }

    }

    private void PlayerHealed(float heal)
    {
        p_life += heal;
        if (p_life > p_maxLife)
        {
            p_life = p_maxLife;
        }
        UpdatePlayerLife();
    }

    private void PlayerDeath()
    {
        //Stopper le jeu
        //Animation de mort du joueur
    }

    private void UpdatePlayerLife()
    {
        //Update affichage de la vie
    }

    private void UpdatePlayerArmor(float newArmorStat)
    {
        p_armor = newArmorStat;
        //Update affichage de l'armure
    }
}
