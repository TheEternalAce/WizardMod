using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class LightningTome : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("The Zap");
        // Tooltip.SetDefault("Creates a breif electric current at the player's cursor, releasing tendrils of electricty");
    }

    public override void SetDefaults()
    {
        Item.damage = 15;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 25;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 50;
        Item.useAnimation = 50;
        Item.useStyle = 5;
        Item.knockBack = 1f;
        Item.value = 10000;
        Item.rare = 3;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.shoot = 1;
        Item.shootSpeed = 7.5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_003e: Unknown result type (might be due to invalid IL or missing references)
        SoundStyle soundStyle = new SoundStyle("WizardMod/Sounds/ElectricZap").WithVolumeScale(3f).WithPitchOffset(Main.rand.NextFloat(0f, 0.3f));
        SoundEngine.PlaySound(soundStyle, (Vector2?)position);
        Vector2 pos = new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y);
        Projectile.NewProjectile((IEntitySource)source, pos, new Vector2(0f, 0f), Mod.Find<ModProjectile>("LightningProj").Type, damage, knockback, player.whoAmI, 2f, 2f);
        return false;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(19, 9);
        recipe.AddIngredient(null, "SkyCrystal", 7);
        recipe.AddIngredient(null, "MagicSoul", 5);
        recipe.AddTile(101);
        recipe.Register();
        Recipe recipe2 = CreateRecipe();
        recipe2.AddIngredient(706, 9);
        recipe2.AddIngredient(null, "SkyCrystal", 7);
        recipe2.AddIngredient(null, "MagicSoul", 5);
        recipe2.AddTile(101);
        recipe2.Register();
    }
}
