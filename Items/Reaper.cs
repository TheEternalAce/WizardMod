using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class Reaper : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("The Reaper");
		// Tooltip.SetDefault("'It was in the restricted section'\nConsumes your foe in dark magic");
	}

	public override void SetDefaults()
	{
		Item.damage = 43;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 19;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 300000;
		Item.rare = 6;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 6.5f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/DarkCastLow").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		int numberProjectiles = 9;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToDegrees(i * 40));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("ReaperProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "NecroticTome");
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(547, 5);
		recipe.AddIngredient(527, 5);
		recipe.AddTile(101);
		recipe.Register();
	}
}
