using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using WizardMod.World;

namespace WizardMod.Items;

public class SorcererTome : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Apprentice Tome");
		// Tooltip.SetDefault("\nShoots a magic bolt that bounces off walls and releases healing bolts on impact\nInflicts Cleansing debuff");
	}

	public override void SetDefaults()
	{
		Item.damage = 17;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 5;
		Item.width = 16;
		Item.height = 32;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.useStyle = 5;
		Item.knockBack = 3f;
		Item.value = 20000;
		Item.rare = 2;
		Item.noMelee = true;
		Item.autoReuse = true;
		Item.shoot = Mod.Find<ModProjectile>("SorcererProj").Type;
		Item.shootSpeed = 5.5f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/EnchantedCast").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)position);
		return true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(4f, 0f);
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
			else
			{
				yOffset = 0;
			}
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(null, "ApprenticeTome");
		recipe.AddIngredient(null, "EnchantedBook");
		recipe.AddIngredient(null, "EnchantedShard", 3);
		recipe.AddIngredient(19, 5);
		recipe.AddTile(101);
		recipe.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(null, "ApprenticeTome");
		recipe2.AddIngredient(null, "EnchantedBook");
		recipe2.AddIngredient(null, "EnchantedShard", 3);
		recipe2.AddIngredient(706, 5);
		recipe2.AddTile(101);
		recipe2.Register();
	}
}
