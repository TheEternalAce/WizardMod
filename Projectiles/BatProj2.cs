using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class BatProj2 : ModProjectile
{
	private int num;

	private int dust_num = 162;

	private int dust_num2 = 6;

	private int time;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Evil Bat");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		Projectile.aiStyle = 1;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 60;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;
		Projectile.scale = 0f;
		Projectile.alpha = 75;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		for (int i = 0; i < 2; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
		}
		return true;
	}

	public override void AI()
	{
		Projectile.width = 24;
		Projectile.height = 24;
		this.time++;
		Projectile.velocity *= 0.97f;
		Projectile.alpha += 2;
		Projectile.aiStyle = 0;
		if (Projectile.scale < 1f)
		{
			Projectile.scale += 0.075f;
		}
	}
}
