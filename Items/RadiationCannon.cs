using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class RadiationCannon : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Radiation Cannon");
		// Tooltip.SetDefault("Launches an ion blast which explodes into lots of homing particles\nInflicts radiation sickness debuff on impact");
	}

	public override void SetDefaults()
	{
		Item.damage = 37;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 16;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 27;
		Item.useAnimation = 27;
		Item.useStyle = 5;
		Item.knockBack = 1f;
		Item.value = 100000;
		Item.rare = 6;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 20;
		Item.shootSpeed = 14f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(2f, 0f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/RadiationLaser").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		Vector2 pos = new Vector2(10f, -10f);
		for (int i = 0; i < 6; i++)
		{
			int xx = Main.rand.Next(-12, 12);
			int yy = Main.rand.Next(-12, 12);
			pos = ((player.direction != 1) ? new Vector2(-16f, -10f) : new Vector2(10f, -10f));
			int dust3 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 75);
			Dust.NewDust(position + pos + pos, Item.width + xx, Item.height + yy, 107);
			int dust4 = Dust.NewDust(position + pos, Item.width + xx, Item.height + yy, 75);
			Main.dust[dust3].noGravity = true;
			Main.dust[dust3].velocity *= 12f;
			Main.dust[dust4].noGravity = true;
			Main.dust[dust4].velocity *= 6f;
		}
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("RadiationProjectile").Type, damage, knockback, player.whoAmI, 2f, 2f);
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "Energizer");
		recipe.AddIngredient(522, 12);
		recipe.AddIngredient(549, 20);
		recipe.AddTile(null, "WizardTable");
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "Energizer");
		recipe2.AddIngredient(1332, 12);
		recipe2.AddIngredient(549, 20);
		recipe2.AddTile(null, "WizardTable");
		recipe2.Register();
	}
}
