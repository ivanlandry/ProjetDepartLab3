using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtCollisionTotal = default;
    [SerializeField] private TMP_Text _txtCollisionNiv1 = default;
    [SerializeField] private TMP_Text _txtCollisionNiv2 = default;
    [SerializeField] private TMP_Text _txtTempsNiv1 = default;
    [SerializeField] private TMP_Text _txtTempsNiv2 = default;
    [SerializeField] private TMP_Text _txtTempsFinal = default;

    // Start is called before the first frame update
    private void Start()
    {
        _txtTempsTotal.text = "Temps total : " + (GestionJeu.Instance.Timer).ToString("f2") + " secondes";
        _txtCollisionTotal.text = "Collisions total : " + GestionJeu.Instance.Pointage.ToString();
        _txtCollisionNiv1.text = "Collisions Niveau 1 : " + GestionJeu.Instance.GetAccrochagesNiveau(1);
        _txtCollisionNiv2.text = "Collisions Niveau 2 : " + (GestionJeu.Instance.Pointage - GestionJeu.Instance.GetAccrochagesNiveau(1));
        _txtTempsNiv1.text= "Temps niveau 1 : "+GestionJeu.Instance.TempsNiveau1.ToString("f2");
        _txtTempsNiv2.text = "Temps niveau 2 : " + (GestionJeu.Instance.Timer- GestionJeu.Instance.TempsNiveau1).ToString("f2");
        _txtTempsFinal.text = "Temps final :" + ((GestionJeu.Instance.Timer) + GestionJeu.Instance.Pointage).ToString("f2") + " secondes";
      
    }

}
