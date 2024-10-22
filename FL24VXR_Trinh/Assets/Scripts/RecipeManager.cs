using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

    // Start is called before the first frame update
    void Start()
    {
        ingredients.Add(new Ingredient("Red Cube", 0, Resources.Load("Ingredients/RedCube") as GameObject, 3));
        ingredients.Add(new Ingredient("Green Cube", 1, Resources.Load("Ingredients/GreenCube") as GameObject, 5));
        ingredients.Add(new Ingredient("Orange Cube", 2, Resources.Load("Ingredients/OrangeCube") as GameObject, 2));
        ingredients.Add(new Ingredient("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject, 8));
        ingredients.Add(new Ingredient("Yellow Sphere", 4, Resources.Load("Ingredients/YellowSphere") as GameObject, 1));

        SpawnIngredients();
    }

    public void SpawnIngredients()
    {
        // loop through the ingredients list
        for (int i = 0; i < ingredients.Count; i++)
        {
            // instantiate each prefab in the ingredients list
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            // rename the object to the associated ingredient ID (will be used when we click on the ingredient prefab)
            tempObj.name = i.ToString();
            // code to offset the ingredients so they are not on top of each other
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + (i * 1), tempV3.y, tempV3.z);
        }
    }
}
