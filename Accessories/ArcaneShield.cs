using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

[AutoloadEquip(new EquipType[] { EquipType.Shield })]
public class ArcaneShield : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Arcane Shield");
		// Tooltip.SetDefault("'You are protected by magic'\nDefense increased by 12%\nWhen hit, a magic barrier is created around the player, dealing damage to anything that comes near you\nThe power of the magic barrier scales with magic critical strike chance\nHas a 10 second cooldown\nGrants knockback and fireblock immunity");
	}

	public override void SetDefaults()
	{
		Item.defense = 2;
		Item.width = 24;
		Item.height = 28;
		Item.value = 0;
		Item.rare = 4;
		Item.value = 150000;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.noKnockback = true;
		player.GetModPlayer<Global>().arcaneShield = true;
		player.statDefense += player.statDefense / 7;
		player.fireWalk = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(156);
		recipe.AddIngredient(null, "EnchantedWard");
		recipe.AddIngredient(193);
		recipe.AddIngredient(null, "ArcaneOrb");
		recipe.AddIngredient(null, "MagicSoul", 15);
		recipe.AddIngredient(null, "EnchantedSilk", 5);
		recipe.AddTile(114);
		recipe.Register();
	}
}
