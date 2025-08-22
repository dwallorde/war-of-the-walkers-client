using System.Collections.Generic;
using Harmony.RecipesPatches;

public class XUiC_AdditionalOutput : XUiController
{
    public Recipe recipe;
    public List<XUiController> additionalOutputEntries = new List<XUiController>();
    public bool isDirty;

    public List<ItemStack> items = new List<ItemStack>();

    public Recipe Recipe
    {
        get
        {
            return this.recipe;
        }
        set
        {
            this.recipe = value;
            items = XUiCRecipeStackOutputStackPatches.XUiCRecipeStackOutputStack.GetAdditionalOutput(recipe, MinEventParams.CachedEventParam);
            this.isDirty = true;
        }
    }
    public override void Init()
    {
        base.Init();
        XUiController[] childrenByType = base.GetChildrenByType<XUiC_IngredientEntry>(null);
        XUiController[] array = childrenByType;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null)
            {
                this.additionalOutputEntries.Add(array[i]);
            }
        }
    }
    public override void Update(float _dt)
    {
        if (this.isDirty)
        {
            if (this.recipe != null)
            {
                //int count = this.additionalOutputEntries.Count;
                var counter = 0;
                foreach (var item in items)
                {
                    if (counter >= additionalOutputEntries.Count) break;
                    if (additionalOutputEntries[counter] is XUiC_IngredientEntry)
                    {
                        ((XUiC_IngredientEntry)this.additionalOutputEntries[counter]).Ingredient =item;
                    }
                    else
                    {
                        ((XUiC_IngredientEntry)this.additionalOutputEntries[counter]).Ingredient = null;
                    }
                    counter++;
                }
            }
            else
            {
                int count3 = this.additionalOutputEntries.Count;
                for (int j = 0; j < count3; j++)
                {
                    if (this.additionalOutputEntries[j] is XUiC_IngredientEntry)
                    {
                        ((XUiC_IngredientEntry)this.additionalOutputEntries[j]).Ingredient = null;
                    }
                }
            }
            this.isDirty = false;
        }
        base.Update(_dt);
    }
}
