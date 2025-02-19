using Terraria;
using Terraria.ModLoader;
using WizardMod.World;

namespace WizardMod.Accessories;

public class ArcaneOrb : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Arcane Orb");
        // Tooltip.SetDefault("Holds pure sorcery magic\nMagic damage and critical strike chance increased by 5%\nSpell power increased by 1");
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 28;
        Item.value = 0;
        Item.rare = 1;
        Item.value = 15000;
        Item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool showVisual)
    {
        player.GetCritChance(DamageClass.Magic) += 5f;
        player.GetDamage(DamageClass.Magic) += 0.05f;
        player.GetModPlayer<Global>().spellPower++;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(181, 5);
        recipe.AddIngredient(null, "InfusedStar", 8);
        recipe.AddTile(null, "ArcaneTable");
        recipe.Register();
    }
}
