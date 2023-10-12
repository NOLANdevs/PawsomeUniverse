using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectYourPetMenu : MonoBehaviour
{

    public enum ChosenPet
    {
        Frog,
        Octopus,
    }

    private ChosenPet chosenPet;

    public void SelectFrog()
    {
        chosenPet = ChosenPet.Frog;
    }

    public void SelectOctopus()
    {
        chosenPet = ChosenPet.Octopus;
    }

    public void PetSelected()
    {
        Debug.Log("Unimplemented");
    }

}
