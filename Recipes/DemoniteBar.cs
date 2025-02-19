using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class DemoniteBar : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Demonite Bar");
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
		Recipe recipe = Recipe.Create(57);
		recipe.AddIngredient(1257);
		recipe.AddTile(16);
		recipe.Register();
	}
}
