using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class LivingProj : ModProjectile
{
	private int time;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Purple Arrow");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 4;
		Projectile.height = 4;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = 999;
		Projectile.light = 0.25f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Main.projFrames[Projectile.type] = 5;
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.timeLeft = 300;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 3; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 3);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 75);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 74);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 61);
		}
	}

	public override void AI()
	{
		if (++Projectile.frameCounter >= 10)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 5)
			{
				Projectile.frame = 0;
			}
		}
		Projectile.scale += (float)Math.Sin((double)(Projectile.timeLeft / 15)) / 150f;
		Projectile.alpha += (int)Math.Sin((double)Projectile.timeLeft);
		_ = Main.player[Projectile.owner];
		this.time++;
		for (int i = 0; i < 100; i++)
		{
			NPC target = Main.npc[i];
			float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
			float shootToY = target.position.Y + 4f - Projectile.Center.Y;
			float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
			if (distance < 260f && !target.friendly && target.active && this.time % 60 == 0 && target.lifeMax > 5)
			{
				distance = 3f / distance;
				shootToX *= distance * 5f;
				shootToY *= distance * 5f;
				Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.Center.X + 8f, Projectile.Center.Y + 8f), new Vector2(shootToX / 2f, shootToY / 2f), Mod.Find<ModProjectile>("EnergyLightning").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				break;
			}
		}
	}
}
