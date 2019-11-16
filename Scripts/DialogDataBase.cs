using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDatabase
{

    string dialog1 = "Eh bien mon beau, tu vas bien ?";
    string dialog2 = "C'est un oeil que t'as là ? flippant... ";
    string dialog3 = "Et ta forme... on dirait... ";
    string dialog4 = "Une banane...";
    string dialog5 = "Je vais te finir.";
    string dialogTuto1 = "Pour jouer à L.S.R il va falloir te servir de ton oreille musicale ! Utilise L/R pour tirer.";  
    string dialogTuto2 = "Tire en rythme pour booster tes projectiles. Sers toi de la musique !";
    string dialogTuto3 = "Pour faire le tir lent (orange), suis la grosse caisse. ";
    string dialogTuto4 = "Pour le tir normal (bleu) cale toi sur l'enchaînement grosse caisse -> caisse claire.";
    string dialogTuto5 = "Enfin pour le tir rapide (rose) il va falloir garder un rythme très rapide.";
    string dialogTuto6 = "Utilise ces trois tirs pour t’adapter aux couleurs de tes ennemis !";
    string dialogTuto7 = "En appuyant sur A tu peux ralentir la vitesse de ton personnage pour plus de précision.";
    string dialogTuto8 = "Appuie sur start pour quitter ce tutoriel !";



    public string ReturnInfos(string name)
    {
        switch (name)
        {
            case "dialog1":
                return dialog1;
            case "dialog2":
                return dialog2;
            case "dialog3":
                return dialog3;
            case "dialog4":
                return dialog4;
            case "dialog5":
                return dialog5;
            case "dialogTuto1":
                return dialogTuto1;
            case "dialogTuto2":
                return dialogTuto2;
            case "dialogTuto3":
                return dialogTuto3;
            case "dialogTuto4":
                return dialogTuto4;
            case "dialogTuto5":
                return dialogTuto5;
            case "dialogTuto6":
                return dialogTuto6;
            case "dialogTuto7":
                return dialogTuto7;
            case "dialogTuto8":
                return dialogTuto8;

            default: return null;
        }
    }
}
