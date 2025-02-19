using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DeepslateTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Ashen Tome");
        // Tooltip.SetDefault("Launches a deepslate assault from the skies");
    }

    public override void SetDefaults()
    {
        Item.damage = 31;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 15;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = 5;
        Item.knockBack = 4f;
        Item.value = 40000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item102;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("AshenTomeProj").Type;
        Item.shootSpeed = 6f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
        float ceilingLimit = target.Y;
        if (ceilingLimit > player.Center.Y - 200f)
        {
            ceilingLimit = player.Center.Y - 200f;
        }
        for (int i = 0; i < 1; i++)
        {
            position = player.Center + new Vector2((0f - (float)Main.rand.Next(0, 250)) * (float)player.direction, -600f);
            position.Y -= 100 * i;
            Vector2 heading = target - position;
            if (heading.Y < 0f)
            {
                heading.Y *= -1f;
            }
            if (heading.Y < 20f)
            {
                heading.Y = 20f;
            }
            heading.Normalize();
            heading *= velocity.Length();
            velocity.X = heading.X;
            velocity.Y = heading.Y + (float)Main.rand.Next(-40, 41) * 0.01f;
            Vector2 newVel = new Vector2(velocity.X * 2.3f, velocity.Y * 2.3f);
            Vector2 vel2 = new Vector2(velocity.X * 2.1f, velocity.Y * 1.9f);
            Vector2 vel3 = new Vector2(velocity.X * 2f, velocity.Y * 2.4f);
            Vector2 vel4 = new Vector2(velocity.X * 2.1f, velocity.Y * 2.7f);
            Vector2 pos1 = new Vector2(position.X - 64f, position.Y);
            Vector2 pos2 = new Vector2(position.X + 64f, position.Y);
            Projectile.NewProjectile((IEntitySource)source, position, newVel, Mod.Find<ModProjectile>("AshenTomeProj").Type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            if (Main.rand.Next(0, 2) == 1)
            {
                Projectile.NewProjectile((IEntitySource)source, pos1, vel2, Mod.Find<ModProjectile>("DeepslateBolt").Type, damage / 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }
            if (Main.rand.Next(0, 2) == 1)
            {
                Projectile.NewProjectile((IEntitySource)source, pos2, vel3, Mod.Find<ModProjectile>("DeepslateBolt").Type, damage / 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }
            if (Main.rand.Next(0, 2) == 1)
            {
                Projectile.NewProjectile((IEntitySource)source, position, vel4, Mod.Find<ModProjectile>("DeepslateBolt").Type, damage / 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }
        }
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 15);
        recipe.AddIngredient(null, "MoltenShard");
        recipe.AddTile(101);
        recipe.Register();
    }
}
