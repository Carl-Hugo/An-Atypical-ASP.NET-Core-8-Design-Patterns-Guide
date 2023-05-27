namespace NinjaShared;

public static class Logic
{
    public static async Task ExecuteSequenceAsync<T>(T firstAttacker, T secondAttacker, Func<string, Task> writeAsync)
        where T : IAttacker
    {
        // The Blue Phantom attacks The Unseen Mirage with a first attack
        var result = firstAttacker.Attack(secondAttacker);
        await PrintAttackResultAsync(result);

        // The Unseen Mirage moves away from The Blue Phantom
        secondAttacker.MoveTo(5, 5);
        await PrintMovementAsync(secondAttacker);

        // The Blue Phantom attacks The Unseen Mirage with a second attack
        var result2 = firstAttacker.Attack(secondAttacker);
        await PrintAttackResultAsync(result2);

        // The Unseen Mirage moves further away from The Blue Phantom
        secondAttacker.MoveTo(20, 20);
        await PrintMovementAsync(secondAttacker);

        // The Blue Phantom attacks The Unseen Mirage with a third attack
        var result3 = firstAttacker.Attack(secondAttacker);
        await PrintAttackResultAsync(result3);

        // The Unseen Mirage strikes back at The Blue Phantom from a distance
        var result4 = secondAttacker.Attack(firstAttacker);
        await PrintAttackResultAsync(result4);

        // Output
        Task PrintAttackResultAsync(AttackResult attackResult)
        {
            if (attackResult.Succeeded)
            {
                return writeAsync($"{attackResult.Attacker} hits {attackResult.Target} using {attackResult.Weapon} at distance {attackResult.Distance}!{Environment.NewLine}");
            }
            else
            {
                return writeAsync($"{attackResult.Attacker} misses {attackResult.Target} using {attackResult.Weapon} at distance {attackResult.Distance}...{Environment.NewLine}");
            }
        }

        Task PrintMovementAsync(ITarget ninja)
            => writeAsync($"{ninja.Name} moved to {ninja.Position}.{Environment.NewLine}");
    }
}
