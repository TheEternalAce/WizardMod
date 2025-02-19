using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DeepslateHamaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Waraxe");
        // Tooltip.SetDefault("Trees hate him!");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(7);
        Item.damage = 29;
        Item.DamageType = DamageClass.Melee;
        Item.width = 36;
        Item.height = 52;
        Item.axe = 25;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = 1;
        Item.knockBack = 3f;
        Item.value = 20000;
        Item.rare = 3;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 10);
        recipe.AddIngredient(173, 3);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }

    public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(Mod.Find<ModBuff>("DeepslateBuff").Type, 60);
        target.AddBuff(24, 60);
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(1))
        {
            int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
            Main.dust[dust2].velocity.Y *= 1f;
            Main.dust[dust2].noGravity = true;
        }
    }
}
