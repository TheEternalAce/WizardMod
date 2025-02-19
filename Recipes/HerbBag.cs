using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class HerbBag : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Herb Bag");
		// Tooltip.SetDefault("Right click to open");
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
		Recipe recipe = Recipe.Create(3093);
		recipe.AddIngredient(3385);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = Recipe.Create(3093);
		recipe2.AddIngredient(3386);
		recipe2.AddIngredient(null, "MagicSoul");
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
		Recipe recipe3 = Recipe.Create(3093);
		recipe3.AddIngredient(3387);
		recipe3.AddIngredient(null, "MagicSoul");
		recipe3.AddTile(null, "ArcaneTable");
		recipe3.Register();
		Recipe recipe4 = Recipe.Create(3093);
		recipe4.AddIngredient(3388);
		recipe4.AddIngredient(null, "MagicSoul");
		recipe4.AddTile(null, "ArcaneTable");
		recipe4.Register();
	}
}
