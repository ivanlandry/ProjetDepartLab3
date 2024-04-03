using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****

    [SerializeField] private int _idNiveau = 1;
    private bool _finPartie = false;  // booléen qui détermine si la partie est terminée
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** Méthode privées  *****
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();  // récupère sur la scène le gameObject de type Player
    }

    /*
     * Méthode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas terminée
        {
            _finPartie = true; // met le booléen à vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // Récupère l'index de la scène en cours
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
