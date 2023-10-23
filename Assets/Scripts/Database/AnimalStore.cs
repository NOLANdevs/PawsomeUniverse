using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStore
{
    private string id, name, species, colour, love, hunger, cleanliness;

    public AnimalStore()
    {
    }

    public AnimalStore(Animal animal)
    {
        this.id = animal.id.ToString();
        this.name = animal.animalName.ToString();
        this.species = animal.species.ToString();
        this.colour = animal.colour.ToString();
        this.love = animal.love.ToString();
        this.hunger = animal.hunger.ToString();
        this.cleanliness = animal.cleanliness.ToString();
    }

    // Apply current object's stats to new animal `animal`
    public void applyToAnimal(Animal animal)
    {
        animal.id = int.Parse(this.id);
        animal.animalName = this.name;
        Enum.TryParse(this.species, out animal.species);
        Enum.TryParse(this.colour, out animal.colour);
        animal.love = float.Parse(this.love);
        animal.hunger = float.Parse(this.hunger);
        animal.cleanliness = float.Parse(this.cleanliness);
    }

    public Animal loadAnimal()
    {
        GameObject animalObj = new GameObject("TEMPORARY_Animal" + this.id);
        Animal animal = animalObj.AddComponent<Animal>();
        applyToAnimal(animal);
        // TODO delete animalObj
        return animal;
    }

    public string createCSVLine()
    {
        List<string> values = new List<string> { id, name, species, colour, love, hunger, cleanliness };
        string writeStr = string.Join(",", values);
        return writeStr + "\n";
    }
    public bool loadCSVLine(string csvLine)
    {
        string[] parts = csvLine.Split(",");
        if (parts.Length != 7)
            return false; // not as valid line

        this.id = parts[0];
        this.name = parts[1];
        this.species = parts[2];
        this.colour = parts[3];
        this.love = parts[4];
        this.hunger = parts[5];
        this.cleanliness = parts[6];

        return true; //success
    }
}
