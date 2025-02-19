using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class GandalfRobe : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Death Eater's Robe");
		// Tooltip.SetDefault("7% increased magic damage and critical strike chance\nMax mana increased by 120");
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = 1250;
		Item.rare = 5;
		Item.defense = 11;
	}

	public override void UpdateEquip(Player player)
	{
		player.statManaMax2 += 120;
		player.GetCritChance(DamageClass.Magic) += 7f;
		player.GetDamage(DamageClass.Magic) += 0.07f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(527, 3);
		recipe.AddIngredient(521, 7);
		recipe.AddIngredient(null, "LunarBar", 18);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
	}
}
