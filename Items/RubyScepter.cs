using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class RubyScepter : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Ruby Pike");
		// Tooltip.SetDefault("Casts a ruby beam while simultaneous stabbing enemies");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 20;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 10;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 3;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 2.5f;
	}

	public override bool CanUseItem(Player player)
	{
		return player.ownedProjectileCounts[Mod.Find<ModProjectile>("RubySpear").Type] < 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		position += new Vector2(velocity.X * 19f, velocity.Y * 19f);
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("RubyBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("RubySpear").Type, damage / 2, knockback, player.whoAmI, 0f, 0f);
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(743);
		recipe.AddIngredient(null, "InfusedStar", 3);
		recipe.AddIngredient(null, "EnchantedShard");
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
