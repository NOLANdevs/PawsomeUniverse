using System;
using System.Collections;
using System.Collections.Generic;

public class AnimalStore
{
    string id, name, species, colour, love, hunger, cleanliness;

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

    public Animal loadAnimal()
    {
        Animal animal = new Animal();

        animal.id = this.id;
        animal.animalName = this.name;
        Enum.TryParse(this.species, out animal.species);
        Enum.TryParse(this.colour, out animal.colour);
        animal.love = float.Parse(this.love);
        animal.hunger = float.Parse(this.hunger);
        animal.cleanliness = float.Parse(this.cleanliness);

        return animal;
    }

    public string createCSVLine()
    {
        List<string> values = new List<string> { id, name, species, colour, love, hunger, cleanliness };
        string writeStr = string.Join(",", values);
        return writeStr + "\n";
    }
}
