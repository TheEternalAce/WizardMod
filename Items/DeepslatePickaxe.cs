using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Items;

public class DeepslatePickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Deepslate Pickaxe");
        // Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(122);
        Item.damage = 14;
        Item.DamageType = DamageClass.Melee;
        Item.width = 36;
        Item.height = 52;
        Item.pick = 105;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = 1;
        Item.knockBack = 1.5f;
        Item.value = 30000;
        Item.rare = 3;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.useTurn = true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(null, "DeepslateBar", 12);
        recipe.AddIngredient(173, 4);
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
