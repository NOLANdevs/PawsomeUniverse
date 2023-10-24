using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectYourPetMenu : MonoBehaviour
{

    public void SelectFrog()
    {
        PlayerPrefs.SetString("NewPetType", "Frog");
    }

    public void SelectOctopus()
    {
        PlayerPrefs.SetString("NewPetType", "Octopus");
    }

    public void PetSelected()
    {
        PlayerPrefs.SetInt("CreateNewPet", 1);
        SceneManager.LoadScene("Main");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("OwnedPets");
    }

}
