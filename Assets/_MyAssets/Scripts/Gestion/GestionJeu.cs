using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    public static GestionJeu Instance;
    
    // ***** Attributs *****
    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    public int Pointage => _pointage; // Accesseur de l'attribut
    public float TempsDepart => _tempsDepart;

    private int[] listeAccrochages = { 0, 0 };
    private float[] listeTemps = { 0.0f, 0.0f };
    private float _tempsDepart = 0f;
 
    // ***** Méthodes privées *****
    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante et associe Instance.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _pointage = 0;
    }

    private void Update()
    {
        //Vérifie si je suis sur une scène qui n'est pas un niveau de jeu
        //Si c'est le cas détruire le GameManager
        if (SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Destroy(gameObject);
        }
    }

    // ***** Méthodes publiques ******

    /*
     * Méthode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiveau(int niveau)
    {
        return listeTemps[niveau-1];
    }
    
    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
   public int GetAccrochagesNiveau(int niveau)
    {
        return listeAccrochages[niveau-1];
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau(int accrochages, float temps, int niveau)
    {
        listeAccrochages[niveau-1] = accrochages;
        listeTemps[niveau-1] = temps;
    }
}
