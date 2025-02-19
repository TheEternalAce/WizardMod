using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class MagicHat : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Magic Hat");
		// Tooltip.SetDefault("6% increased magic damage and critical strike chance");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 30000;
		Item.rare = 2;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(2275);
		recipe.AddIngredient(181, 3);
		recipe.AddIngredient(null, "EnchantedSilk", 8);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
