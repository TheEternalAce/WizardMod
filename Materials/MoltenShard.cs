using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Materials;

public class MoltenShard : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Molten Shard");
		// Tooltip.SetDefault("'It is imbued with fire magic'");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 10000;
		Item.rare = 2;
		Item.noMelee = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(2);
		recipe.AddIngredient(null, "MagicSoul");
		recipe.AddIngredient(318);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
