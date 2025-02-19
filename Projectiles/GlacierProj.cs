using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class GlacierProj : ModProjectile
{
	private int dust_num = 213;

	private int dust_num2 = 135;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 20;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 5;
		Projectile.timeLeft = 220;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 7; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, this.dust_num2);
		}
		_ = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Projectile.aiStyle = 0;
		Player player = Main.player[Projectile.owner];
		if (Projectile.timeLeft % 10 == 0)
		{
			_ = Projectile.Center;
			float projectilespeedX = 5f;
			float projectilespeedY = 5f;
			float projectileknockBack = 3f;
			Vector2 vector = new Vector2(projectilespeedX, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f));
			projectilespeedX = vector.X;
			projectilespeedY = vector.Y;
			Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(projectilespeedX, projectilespeedY), 337, Projectile.damage, projectileknockBack, player.whoAmI, 0f, 0f);
		}
		if (Main.rand.Next(1) == 0)
		{
			for (int i = 0; i < 35; i++)
			{
				int xx = Main.rand.Next(0, 24);
				int yy = Main.rand.Next(0, 24);
				Vector2 position = Projectile.position;
				int dust = Dust.NewDust(position, 1 + xx, 1 + yy, 213);
				Main.dust[dust].velocity *= 2f;
				Main.dust[dust].scale = (float)Main.rand.Next(5, 165) * 0.013f;
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(position, 1 + xx, 1 + yy, 135);
				Main.dust[dust2].velocity *= 2f;
				Main.dust[dust2].scale = (float)Main.rand.Next(5, 165) * 0.013f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 35; i++)
		{
			int xx = Main.rand.Next(0, 24);
			int yy = Main.rand.Next(0, 24);
			Vector2 position = Projectile.position;
			int dust = Dust.NewDust(position, 1 + xx, 1 + yy, 213);
			Main.dust[dust].velocity *= 6f;
			Main.dust[dust].scale = (float)Main.rand.Next(5, 165) * 0.013f;
			Main.dust[dust].noGravity = true;
			int dust2 = Dust.NewDust(position, 1 + xx, 1 + yy, 135);
			Main.dust[dust2].velocity *= 6f;
			Main.dust[dust2].scale = (float)Main.rand.Next(5, 165) * 0.013f;
			Main.dust[dust2].noGravity = true;
		}
		_ = Main.player[Projectile.owner];
		SoundEngine.PlaySound(SoundID.NPCHit5, (Vector2?)Projectile.position);
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		_ = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		target.AddBuff(44, 180);
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
	}
}
