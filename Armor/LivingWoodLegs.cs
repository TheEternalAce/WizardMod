using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class LivingWoodLegs : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Living Leggings");
		// Tooltip.SetDefault("5% Increased movement speed");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1000;
		Item.rare = 1;
		Item.defense = 1;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.05f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(9, 30);
		recipe.AddIngredient(null, "LivingShard");
		recipe.AddIngredient(null, "EnchantedSilk", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
