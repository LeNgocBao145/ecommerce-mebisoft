using PromotionService.Domain.Enums;

namespace PromotionService.Domain.Policies
{
    public static class UserRankPolicy
    {
        // MinPoints để đạt rank đó
        public static readonly Dictionary<UserRank, int> MinPoints = new()
        {
            [UserRank.BRONZE] = 0,
            [UserRank.SILVER] = 100,
            [UserRank.GOLD] = 500,
            [UserRank.DIAMOND] = 2000,
        };

        public static UserRank CalculateRank(int totalPoints)
        {
            return MinPoints
                .Where(x => totalPoints >= x.Value)
                .OrderByDescending(x => x.Value)
                .First()
                .Key;
        }
    }
}
