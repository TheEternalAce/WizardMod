using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class AshenStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Staff");
        // Tooltip.SetDefault("Launches a volley of flaming rocks");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(3870);
        Item.damage = 32;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 14;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.useStyle = 5;
        Item.knockBack = 6f;
        Item.value = 30000;
        Item.rare = 4;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("AshenProj").Type;
        Item.shootSpeed = 11f;
    }

    public override void HoldItem(Player player)
    {
        player.itemLocation.Y = player.Center.Y + 4f;
        player.itemLocation.X = player.Center.X + (float)(2 * player.direction);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int num371 = 0; num371 < 7; num371++)
        {
            int num372 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num372].noGravity = true;
            Main.dust[num372].velocity *= 5f;
            num372 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num372].velocity *= 3f;
        }
        Vector2 pos = new Vector2(position.X - 2f, position.Y - 10f);
        Projectile.NewProjectile((IEntitySource)source, pos, velocity, Mod.Find<ModProjectile>("AshenProj").Type, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile((IEntitySource)source, pos, velocity, Mod.Find<ModProjectile>("AshenProj2").Type, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 12);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
