using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RelicRock : ModProjectile
{
	private int dust_num = 162;

	private int dust_num2 = 6;

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
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.scale = 1f;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		Dust.NewDust(Projectile.position, Projectile.width + 24, Projectile.height - 24, 32);
		Dust.NewDust(Projectile.position, Projectile.width - 24, Projectile.height, 32);
		Dust.NewDust(Projectile.position, Projectile.width + 12, Projectile.height + 24, 32);
		Dust.NewDust(Projectile.position, Projectile.width - 12, Projectile.height - 48, 32);
		Dust.NewDust(Projectile.position, Projectile.width, Projectile.height + 48, 32);
		Projectile.rotation += 0.035f;
		if (Projectile.timeLeft < 570 && Projectile.velocity.Y > -12f)
		{
			Projectile.velocity.Y += 0.175f;
		}
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(31, 60);
	}

	public override void OnKill(int timeLeft)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.player[Main.myPlayer];
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 24f, Projectile.position.Y + 8f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("Explosion").Type, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
		float numberProjectiles = 3 + Main.rand.Next(3);
		_ = Vector2.Normalize(new Vector2(5f, 5f)) * 45f;
		for (int j = 0; (float)j < numberProjectiles; j++)
		{
			float rotation = MathHelper.ToRadians(35 * Main.rand.Next(10));
			Vector2 perturbedSpeed = new Vector2(3f, 5f).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)j / (numberProjectiles - 1f))) * 0.2f;
			Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X, Projectile.position.Y - 32f), new Vector2(perturbedSpeed.X * 2f, -4f), Mod.Find<ModProjectile>("RelicRockSmash").Type, Projectile.damage, 0f, player.whoAmI, 0f, 0f);
		}
		SoundEngine.PlaySound(SoundID.Item14, (Vector2?)Projectile.position);
		for (int num369 = 0; num369 < 24; num369++)
		{
			int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 32, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num370].velocity *= 1.4f;
			Main.dust[num370].noGravity = true;
		}
		for (int num371 = 0; num371 < 10; num371++)
		{
			int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 85, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[num372].noGravity = true;
			Main.dust[num372].velocity *= 6f;
			num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 268, 0f, 0f, 100, default(Color), 1.5f);
			Main.dust[num372].velocity *= 12f;
			Main.dust[num372].noGravity = true;
		}
		for (int i = 0; i < 24; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 268);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 85);
			Main.dust[dust2].velocity *= 8f;
		}
	}
}
