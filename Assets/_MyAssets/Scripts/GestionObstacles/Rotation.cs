using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ***** Attributs *****
    
    [SerializeField] private float _vitesseRotation = 0.5f;  // �tabli la vitesse de rotation du gameObject
 
    // ***** M�thodes publiques *****

    // On utilise le FixedUpdate car l'objet va g�rer des collisions avec un ou des rigidbody
    void FixedUpdate()
    {
        transform.Rotate(0f, _vitesseRotation, 0f);  // �tabli une rotation du gameObject autour de l'axe des Y
    }
}
