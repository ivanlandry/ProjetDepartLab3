using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerGame : MonoBehaviour
{

    public static UIManagerGame Instance;

    [SerializeField] private TMP_Text _textTenps = default;
    [SerializeField] private TMP_Text _txtCollisions = default;

    private void Start()
    {
        _txtCollisions.text = "Collisions : " + GestionJeu.Instance.Pointage;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float temps = Time.time - GestionJeu.Instance.TempsDepart;
        _textTenps.text = "Temps : "+ temps.ToString("f2");
    }

    public void ChangerCollisions(int pointage)
    {
        _txtCollisions.text = "Collisions : " + pointage.ToString();
    }
}
