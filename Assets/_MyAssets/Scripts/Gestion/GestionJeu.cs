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
 
    // ***** M�thodes priv�es *****
    private void Awake()
    {
        // V�rifie si un gameObject GestionJeu est d�j� pr�sent sur la sc�ne si oui
        // on d�truit celui qui vient d'�tre ajout�. Sinon on le conserve pour le 
        // sc�ne suivante et associe Instance.
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
        //V�rifie si je suis sur une sc�ne qui n'est pas un niveau de jeu
        //Si c'est le cas d�truire le GameManager
        if (SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Destroy(gameObject);
        }
    }

    // ***** M�thodes publiques ******

    /*
     * M�thode publique qui permet d'augmenter le pointage de 1
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

    // M�thode qui re�oit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau(int accrochages, float temps, int niveau)
    {
        listeAccrochages[niveau-1] = accrochages;
        listeTemps[niveau-1] = temps;
    }
}
