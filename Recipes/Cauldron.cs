using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Recipes;

public class Cauldron : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Cauldron");
		// Tooltip.SetDefault("Hmm... needs more salt!\nUsed to brew spells");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 52;
		Item.maxStack = 999;
		Item.value = 100;
		Item.rare = 0;
	}

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(1791);
		recipe.AddRecipeGroup("IronBar", 2);
		recipe.AddRecipeGroup("Wood", 2);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddTile(16);
		recipe.Register();
	}
}
