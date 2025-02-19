using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class GandalfLegs : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Death Eater's Pants");
		// Tooltip.SetDefault("15% increased movement speed\nCritical strike mana recovery increased by 4\nSpell power increased by 5");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1000;
		Item.rare = 5;
		Item.defense = 9;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetModPlayer<Global>().manaOnHit += 4;
		player.GetModPlayer<Global>().spellPower += 5;
		player.moveSpeed += 0.15f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(527, 2);
		recipe.AddIngredient(521, 5);
		recipe.AddIngredient(null, "LunarBar", 12);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
