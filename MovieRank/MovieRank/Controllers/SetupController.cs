using Microsoft.AspNetCore.Mvc;
using MovieRank.Services;

namespace MovieRank.Controllers
{
    public class SetupController : Controller
    {
        private readonly ISetupService _setup;

        public SetupController(ISetupService setup)
        {
            _setup = setup;
        }

        [HttpPost]
        [Route("createtable/{dynamoDbTableName}")]
        public async Task<IActionResult> CreateDynamoDbTable(string dynamoDbTableName)
        {
            await _setup.CreatDynamoDbTable(dynamoDbTableName);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteTable/{dynamoDbTableName}")]
        public async Task<IActionResult> DeleteDynamoDbTable(string dynamoDbTableName)
        {
            await _setup.DeleteDynamoDbTable(dynamoDbTableName);

            return Ok();
        }
    }
}
