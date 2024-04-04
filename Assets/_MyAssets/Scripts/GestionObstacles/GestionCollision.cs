using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // ***** Attributs *****
    [SerializeField] private Material _materielRouge;
    [SerializeField] private float _delaiReactivation = 4f;
    private Material _materielInitial;
    private bool _touche;  // Bool�en qui permet de d�tecter si l'objet a �t� touch�
    private float _tempsTouche = 0f;
    

    // ***** M�thodes priv�es *****
    private void Start()
    {
        _materielInitial = GetComponent<MeshRenderer>().material;
        _touche= false;  // initialise le bool�en � faux au d�but de la sc�ne
    }

    private void Update()
    {
        if (Time.time > (_tempsTouche + _delaiReactivation) && _touche)
        {
            gameObject.GetComponent<MeshRenderer>().material = _materielInitial;
            _touche = false;
            
        }
    }

    /* 
     * R�le : M�thode qui se d�clenche quand une collision se produit avec l'objet
     * Entr�e : un objet de type Collision qui repr�sente l'objet avec qui la collision s'est produite
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_touche)  // Si l'objet avec la collision s'est produite est le joueur et qu'il n'a pas d�j� et touch�
        {
            _touche = true;  // change le bool�en � vrai pour indiqu� que l'objet a �t� touch�
            gameObject.GetComponent<MeshRenderer>().material = _materielRouge;  //change la couleur du mat�riel � rouge
            GestionJeu.Instance.AugmenterPointage();  // Appelle la m�thode publique dans GestionJeu pour augmenter le pointage
            _tempsTouche = Time.time;
        }
    }
}
