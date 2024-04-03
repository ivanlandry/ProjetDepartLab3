using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****

    [SerializeField] private int _idNiveau = 1;
    private bool _finPartie = false;  // bool�en qui d�termine si la partie est termin�e
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** M�thode priv�es  *****
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();  // r�cup�re sur la sc�ne le gameObject de type Player
    }

    /*
     * M�thode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas termin�e
        {
            _finPartie = true; // met le bool�en � vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
            GestionJeu.Instance.SetNiveau(GestionJeu.Instance.Pointage, Time.time - _player.GetTempsDepart(), _idNiveau);
            if (noScene != SceneManager.sceneCountInBuildSettings -1)
            {
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                Destroy(_player);
            }

        }
    }
}
