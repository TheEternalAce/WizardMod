using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Scrolls;

public class CharredScroll : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Charred Scroll");
		// Tooltip.SetDefault("Creates a massive explosion of fire on use");
	}

	public override void SetDefaults()
	{
		Item.damage = 21;
		Item.DamageType = DamageClass.Magic;
		Item.consumable = true;
		Item.width = 16;
		Item.height = 32;
		Item.maxStack = 999;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 10000;
		Item.rare = 3;
		Item.autoReuse = true;
		Item.noMelee = true;
		Item.shoot = Mod.Find<ModProjectile>("CharredScrollProj").Type;
		Item.noUseGraphic = true;
		Item.shootSpeed = 30f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/Paper").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		float numberProjectiles = 8f;
		float rotation = MathHelper.ToRadians(180f);
		position += Vector2.Normalize(velocity) * 90f;
		for (int i = 0; (float)i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f))) * 0.2f;
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 15, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 34, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 85, damage, knockback, player.whoAmI, 2f, 2f);
			Projectile.NewProjectile((IEntitySource)source, new Vector2(player.Center.X + (float)(player.direction * 24), player.position.Y + 12f), perturbedSpeed, 400, damage, knockback, player.whoAmI, 2f, 2f);
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "Scroll");
		recipe.AddIngredient(null, "MoltenShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
