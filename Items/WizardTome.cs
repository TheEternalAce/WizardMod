using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using WizardMod.World;

namespace WizardMod.Items;

public class WizardTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Wizard's Tome");
		// Tooltip.SetDefault("Launches a rapid assault of magic\nCentral bolt homes in on enemies\nGreatly heals allies");
	}

	public override void SetDefaults()
	{
		Item.damage = 37;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 11;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 14;
		Item.useAnimation = 14;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 200000;
		Item.rare = 4;
		Item.noMelee = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = 1;
		Item.shootSpeed = 8.5f;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		Player player = Main.LocalPlayer;
		string sepText = "Heals ally life by " + player.GetModPlayer<Global>().spellPower;
		tooltips.Add(new TooltipLine(Mod, "name", sepText));
	}

	public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
	{
		if (!line.OneDropLogo)
		{
			Player player = Main.player[Main.myPlayer];
			float sepHeight = 0f;
			if (line.Name == "ItemName" && line.Mod == "Terraria")
			{
				float drawX = (float)line.X + line.Font.MeasureString(line.Text).X;
				float drawY = line.Y;
				new Color(100, 100, 255);
				ChatManager.DrawColorCodedStringWithShadow(baseColor: new Color(100, 255, 100), spriteBatch: Main.spriteBatch, font: line.Font, text: " (" + player.GetModPlayer<Global>().spellPower + " Spell power)", position: new Vector2(drawX, drawY), rotation: line.Rotation, origin: line.Origin, baseScale: line.BaseScale, maxWidth: line.MaxWidth, spread: line.Spread);
				yOffset = (int)sepHeight;
			}
		}
		return true;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 1;
		float rotation = MathHelper.ToRadians(0f);
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, i / numberProjectiles));
			Projectile.NewProjectile((IEntitySource)source, position, perturbedSpeed, Mod.Find<ModProjectile>("WizardProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		int numProjectiles2 = 1;
		float spread = MathHelper.ToRadians(10f);
		double startAngle = Math.Atan2((double)velocity.X, (double)velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / (float)numProjectiles2;
		for (int k = 0; k < numProjectiles2; k++)
		{
			double offsetAngle = startAngle + deltaAngle * (double)k;
			Projectile.NewProjectile((IEntitySource)source, position, velocity * (float)Math.Sin(offsetAngle), Mod.Find<ModProjectile>("BlueMagicProj").Type, damage / 2, knockback, player.whoAmI, 0f, 0f);
		}
		int numProjectiles3 = 1;
		float num = MathHelper.ToRadians(-10f);
		double startAngle2 = Math.Atan2((double)velocity.X, (double)velocity.Y) - (double)(spread / 2f);
		double deltaAngle2 = num / (float)numProjectiles3;
		for (int j = 0; j < numProjectiles2; j++)
		{
			double offsetAngle2 = startAngle2 + deltaAngle2 * (double)j;
			Projectile.NewProjectile((IEntitySource)source, position, velocity * (float)Math.Sin(offsetAngle2), Mod.Find<ModProjectile>("BlueMagicProj").Type, damage / 2, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "MasterTome");
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(502, 12);
		recipe.AddIngredient(521, 5);
		recipe.AddIngredient(520, 5);
		recipe.AddTile(101);
		recipe.Register();
	}
}
