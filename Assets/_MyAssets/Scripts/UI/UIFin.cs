using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIFin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtCollisionTotal = default;
    [SerializeField] private TMP_Text _txtCollisionNiv1 = default;
    [SerializeField] private TMP_Text _txtCollisionNiv2 = default;
    [SerializeField] private TMP_Text _txtTempsFinal = default;

    // Start is called before the first frame update
    private void Start()
    {
        _txtTempsTotal.text = "Temps total : " + (Time.time - GestionJeu.Instance.TempsDepart).ToString("f2") + " secondes";
        _txtCollisionTotal.text = "Collisions total : " + GestionJeu.Instance.Pointage.ToString();
        _txtCollisionNiv1.text = "Collisions Niveau 1 : " + GestionJeu.Instance.GetAccrochagesNiveau(1);
        _txtCollisionNiv2.text = "Collisions Niveau 2 : " + (GestionJeu.Instance.Pointage - GestionJeu.Instance.GetAccrochagesNiveau(1));
        _txtTempsFinal.text = "Temps final :" + ((Time.time - GestionJeu.Instance.TempsDepart) + GestionJeu.Instance.Pointage).ToString("f2") + " secondes";
      
    }

}
