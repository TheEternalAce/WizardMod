using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class MoltenRing : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Molten Ring");
		// Tooltip.SetDefault("While in combat, a phoenix will occasionally dive bomb your enemies\nMagic attacks have a chance to inflict deep burns");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 28;
		Item.rare = 3;
		Item.value = 10000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<Global>().moltenRing = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MetalBand");
		recipe.AddIngredient(null, "MoltenShard");
		recipe.AddIngredient(19, 5);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "MetalBand");
		recipe2.AddIngredient(null, "MoltenShard");
		recipe2.AddIngredient(706, 5);
		recipe2.AddTile(null, "ArcaneTable");
		recipe2.Register();
	}
}
