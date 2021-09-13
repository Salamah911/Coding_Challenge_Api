using Coding.Challenge.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Coding.Challenge.Api.Tests.Controllers
{
    public class CodingChallengeControllerTests
    {
        [Fact]
        public void Get_OnInvoke_ReturnsExpectedMessage()
        {
            var controller = new CodingChallengeController();

            var result = controller.Get().Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be("Coding Challenge!");
        }
    }
}
