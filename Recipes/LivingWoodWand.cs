using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class LivingWoodWand : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Wood Wand");
		// Tooltip.SetDefault("Consumes wood\nPlaces living wood");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 1;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(832);
		recipe.AddRecipeGroup("Wood", 25);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddIngredient(null, "LivingShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
