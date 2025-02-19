using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class MoltenSphere : ModProjectile
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
		Projectile.timeLeft = 420;
		Projectile.alpha = 255;
	}

	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 8; i++)
		{
			int dust5 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, 6);
			Main.dust[dust5].velocity *= 4f;
			Main.dust[dust5].noGravity = true;
			int dust6 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, 158);
			Main.dust[dust6].velocity *= 5f;
			Main.dust[dust6].noGravity = true;
		}
	}

	public override void AI()
	{
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		Projectile.alpha -= 2;
		if (++Projectile.frameCounter >= 10)
		{
			Projectile.frameCounter = 0;
			if (++Projectile.frame >= 5)
			{
				Projectile.frame = 0;
			}
		}
		int dust5 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, 6);
		Main.dust[dust5].velocity *= 0f;
		Main.dust[dust5].noGravity = true;
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
			if (distance < 480f && !target.friendly && target.active && this.time % 20 == 0 && target.lifeMax > 5)
			{
				SoundEngine.PlaySound(SoundID.Item20, (Vector2?)Projectile.position);
				distance = 3f / distance;
				shootToX *= distance * 5f;
				shootToY *= distance * 5f;
				Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.Center.X + 8f, Projectile.Center.Y + 8f), new Vector2(shootToX / 2f, shootToY / 2f), Mod.Find<ModProjectile>("MagmaLightning").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				break;
			}
		}
	}
}
