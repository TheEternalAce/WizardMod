using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Consumable;

public class EnchantedDaggerProjectile : ModProjectile
{
    private int dust_num = 162;

    private int dust_num2 = 6;

    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Sand Proj2");
    }

    public override void SetDefaults()
    {
        Projectile.aiStyle = 1;
        Projectile.timeLeft = 600;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.width = 8;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.height = 14;
        Projectile.penetrate = 5;
        Projectile.light = 0.1f;
        Projectile.ignoreWater = false;
        Projectile.tileCollide = true;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        //IL_00a8: Unknown result type (might be due to invalid IL or missing references)
        if (Main.rand.Next(0, 3) == 1)
        {
            Item.NewItem(Main.LocalPlayer.GetSource_DropAsItem(), Projectile.getRect(), Mod.Find<ModItem>("EnchantedDagger").Type);
        }
        for (int i = 0; i < 7; i++)
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
        }
        SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
        return true;
    }

    public override void AI()
    {
        Projectile.width = 8;
        Projectile.height = 14;
        if (Projectile.aiStyle == 1)
        {
            Projectile.aiStyle = 0;
        }
        if (Projectile.timeLeft < 575)
        {
            if (Projectile.aiStyle == 0)
            {
                Projectile.velocity.Y += 2f;
            }
            Projectile.velocity.X *= 0.97f;
            Projectile.aiStyle = 2;
            Projectile.velocity.Y += 0.125f;
        }
        Projectile.width = 14;
        Projectile.height = 14;
        Player player = Main.player[Projectile.owner];
        if (Main.rand.Next(3) == 0)
        {
            for (int i = 0; i < 1; i++)
            {
                Vector2 position = Projectile.position;
                int xx = -40 * player.direction;
                int yy = Main.rand.Next(-24, 24);
                int dust2 = Dust.NewDust(position, 1 + xx, 1 + yy, 15);
                Main.dust[dust2].velocity = Projectile.velocity / 2f;
                Main.dust[dust2].scale = (float)Main.rand.Next(25, 125) * 0.013f;
                Main.dust[dust2].noGravity = true;
                int dust3 = Dust.NewDust(position, 1 + xx, 1 + yy, 112);
                Main.dust[dust3].velocity = Projectile.velocity;
                Main.dust[dust3].scale = (float)Main.rand.Next(25, 125) * 0.013f;
                Main.dust[dust3].noGravity = true;
            }
        }
    }

    public override void OnKill(int timeLeft)
    {
        _ = Main.player[Projectile.owner];
        for (int num369 = 0; num369 < 3; num369++)
        {
            int num370 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 112, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num370].velocity *= 0.4f;
            Main.dust[num370].noGravity = true;
        }
        for (int num371 = 0; num371 < 2; num371++)
        {
            int num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num372].noGravity = true;
            Main.dust[num372].velocity *= 5f;
            num372 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 15, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num372].velocity *= 1f;
        }
        for (int i = 0; i < 3; i++)
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 112);
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15);
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity.Y *= 0.7f;
        }
    }
}
