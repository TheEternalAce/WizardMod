using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class MagmaSphere : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Magma Sphere");
        // Tooltip.SetDefault("\nCasts glowing spheres of flaming energy which zaps nearby enemies\nMultiple spheres can exist at the same time");
    }

    public override void SetDefaults()
    {
        Item.damage = 66;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 25;
        Item.width = 16;
        Item.height = 32;
        Item.useTime = 42;
        Item.useAnimation = 42;
        Item.knockBack = 5f;
        Item.useStyle = 5;
        Item.value = 500000;
        Item.rare = 9;
        Item.noMelee = true;
        Item.UseSound = SoundID.Item20;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("MoltenSphere").Type;
        Item.shootSpeed = 1f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(4f, 0f);
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        position = new Vector2(player.position.X, player.Center.Y);
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(1266);
        recipe.AddIngredient(null, "FireBolt");
        recipe.AddTile(null, "WizardTable");
        recipe.Register();
    }
}
