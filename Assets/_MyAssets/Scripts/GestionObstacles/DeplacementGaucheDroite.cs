using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementGaucheDroite : MonoBehaviour
{
    private float _positionInitialeX;
    [SerializeField] private float _distanceDeplacement = 17f;
    [SerializeField] private float _vitesseDeplacement = 5f;
    private bool _mouvementDroite = true;


    void Start()
    {
        _positionInitialeX = transform.position.x;        
    }

    
    void Update()
    {
        if (transform.position.x < _positionInitialeX)
        {
            _mouvementDroite = true;
        }
        else if (transform.position.x > (_positionInitialeX + _distanceDeplacement))
        {
            _mouvementDroite = false;
        }
        
        if(_mouvementDroite)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _vitesseDeplacement);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * _vitesseDeplacement);
        }
    }
}
