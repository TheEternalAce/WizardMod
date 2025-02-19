using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class Scroll : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Scroll");
		// Tooltip.SetDefault("Used to craft magic scrolls and runes");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 1000;
		Item.rare = 1;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "Paper", 5);
		recipe.AddIngredient(null, "EnchantedSilk");
		recipe.AddIngredient(965);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
