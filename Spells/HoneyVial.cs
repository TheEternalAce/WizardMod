using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Spells;

public class HoneyVial : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Honey Vial");
		// Tooltip.SetDefault("Sweet and... wait, salty?\nUsed to brew honey spells");
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 26;
		Item.useStyle = 2;
		Item.useAnimation = 17;
		Item.useTime = 17;
		Item.useTurn = true;
		Item.UseSound = SoundID.Item3;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.rare = 3;
		Item.healLife = 125;
		Item.potion = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "GlassVial");
		recipe.HasCondition(Condition.NearHoney);
		recipe.Register();
	}
}
