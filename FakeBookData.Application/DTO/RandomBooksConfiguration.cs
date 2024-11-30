using FakeBookData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application.DTO
{
    public record RandomBooksConfiguration(
        int BookCount,
        FakerLocale Locale,
        int Seed,
        float LikeCount,
        float ReviewCount);
}
