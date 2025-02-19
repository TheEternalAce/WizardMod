using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class TopazScepter : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Topaz Stave");
		// Tooltip.SetDefault("Shoots a yellow beam of light that ricochets off walls");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 13;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 5;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.useStyle = 5;
		Item.knockBack = 4f;
		Item.value = 10000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 8f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		position += velocity * 3f;
		Projectile.NewProjectile((IEntitySource)source, position, velocity, Mod.Find<ModProjectile>("TopazBeam").Type, damage, knockback, player.whoAmI, 0f, 0f);
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(740);
		recipe.AddIngredient(null, "InfusedStar", 3);
		recipe.AddTile(null, "ArcaneTable");
		recipe.Register();
	}
}
