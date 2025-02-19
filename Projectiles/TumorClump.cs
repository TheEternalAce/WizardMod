using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class TumorClump : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

	private bool hit;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 120;
		Projectile.light = 0.2f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override void AI()
	{
		Projectile.rotation += 0.025f;
		if (Main.rand.Next(0, 3) == 1)
		{
			int dust6 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 5);
			Main.dust[dust6].velocity *= 0.25f;
		}
		Projectile.friendly = true;
		if (Projectile.alpha > 70)
		{
			Projectile.alpha -= 15;
			if (Projectile.alpha < 70)
			{
				Projectile.alpha = 70;
			}
		}
		if (Projectile.localAI[0] == 0f)
		{
			this.AdjustMagnitude(ref Projectile.velocity);
			Projectile.localAI[0] = 1f;
		}
		Vector2 move = Vector2.Zero;
		float distance = 480f;
		bool target = false;
		for (int i = 0; i < 200; i++)
		{
			if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].lifeMax > 5)
			{
				Vector2 newMove = Main.npc[i].Center - Projectile.Center;
				float distanceTo = (float)Math.Sqrt((double)(newMove.X * newMove.X + newMove.Y * newMove.Y));
				if (distanceTo < distance)
				{
					Projectile.tileCollide = false;
					move = newMove;
					distance = distanceTo;
					target = true;
				}
			}
		}
		if (target)
		{
			Projectile.tileCollide = false;
			Projectile.rotation += 0.05f;
			int dust5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 5);
			Main.dust[dust5].velocity.Y *= 4f;
			this.AdjustMagnitude(ref move);
			Projectile.velocity = (10f * Projectile.velocity + move) / 11f;
			this.AdjustMagnitude(ref Projectile.velocity);
		}
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt((double)(vector.X * vector.X + vector.Y * vector.Y));
		if (magnitude > 8.5f)
		{
			vector *= 8.5f / magnitude;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (!this.hit)
		{
			Projectile.timeLeft = 120;
		}
		this.hit = true;
		Player player = Main.player[Projectile.owner];
		if (crit)
		{
			int healingAmount = damage / 8;
			player.statLife += healingAmount;
			player.HealEffect(healingAmount);
		}
		_ = Main.player[Projectile.owner];
		_ = Projectile.Center;
	}

	public override void OnKill(int timeLeft)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		_ = Main.player[Projectile.owner];
		SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/Squish").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
		SoundEngine.PlaySound(soundStyle, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 16; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 5, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 12, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 4f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 5, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 5f;
		}
	}
}
