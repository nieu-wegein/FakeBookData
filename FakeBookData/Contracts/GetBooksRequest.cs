using FakeBookData.Application.DTO;
using FakeBookData.Enums;

namespace FakeBookData.Contracts
{
    public record GetBooksRequest(
        int StartIndex,
        int BookCount,
        FakerLocale Locale,
        int Seed,
        float LikeCount,
        float ReviewCount)
    {
        public RandomBooksConfiguration ToApplicationDTO()
        {
            return new RandomBooksConfiguration(BookCount, Locale, Seed, LikeCount, ReviewCount);
        }
    }
}
