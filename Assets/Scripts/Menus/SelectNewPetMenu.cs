using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectYourPetMenu : MonoBehaviour
{

    public enum ChosenPet
    {
        FROG,
        FOO,
    }

    private ChosenPet chosenPet;

    public void SelectFrog()
    {
        chosenPet = ChosenPet.FROG;
    }

    public void SelectFoo()
    {
        chosenPet = ChosenPet.FOO;
    }

    public void PetSelected()
    {
        Debug.Log("Unimplemented");
    }

}
